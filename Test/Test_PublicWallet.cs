using Euro2024Stat.WalletAPI.Service;
using EURO2024Stat.DATA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test_PublicWallet
{
	public class Test_PublicWallet
	{
		private readonly DbContextOptions<WalletContext> _options;
		private readonly WalletContext _context;
		private readonly WalletService _service;


		public Test_PublicWallet()
		{
			_options = new DbContextOptionsBuilder<WalletContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_context = new WalletContext(_options);
			_service = new WalletService(_context);

			MockDbSetExtensions.SeedData_WalletContext(_context);
		}


		[Theory]
		[InlineData("user4", "User Four", 0)]
		[InlineData("user5", "User Five", 0)]
		public async Task CreateWallet_WithValidData_CreatesNewWallet(string userId, string userName, decimal expectedBalance)
		{
			// Act
			await _service.CreateWallet(userId, userName);

			// Assert
			var wallet = await _context.Wallet.SingleOrDefaultAsync(x => x.UserID == userId);
			Assert.NotNull(wallet);
			Assert.Equal(userName, wallet.UserName);
			Assert.Equal(expectedBalance, wallet.Balance);
		}

		[Theory]
		[InlineData("user1", 100.00)]
		[InlineData("user2", 200.00)]
		[InlineData("user3", 300.00)]
		public async Task GetBalance_WithValidUserId_ReturnsCorrectBalance(string userId, decimal expectedBalance)
		{
			// Act
			var balance = await _service.GetBalance(userId);

			// Assert
			Assert.Equal(expectedBalance, balance);
		}

		[Theory]
		[InlineData("user1", 50.00, 150.00)]
		[InlineData("user2", 100.00, 300.00)]
		public async Task Deposit_WithValidAmount_UpdatesBalance(string userId, decimal depositAmount, decimal expectedBalance)
		{
			// Act
			await _service.Deposit(userId, depositAmount);

			// Assert
			var wallet = await _context.Wallet.SingleOrDefaultAsync(x => x.UserID == userId);
			Assert.NotNull(wallet);
			Assert.Equal(expectedBalance, wallet.Balance);
		}

		[Theory]
		[InlineData("user1", 50.00, 50.00, true)]
		[InlineData("user2", 300.00, 200.00, false)]
		public async Task Withdraw_WithValidAmount_UpdatesBalance(string userId, decimal withdrawAmount, decimal expectedBalance, bool expectedResult)
		{
			// Act
			var result = await _service.Withdraw(userId, withdrawAmount);

			// Assert
			Assert.Equal(expectedResult, result);
			var wallet = await _context.Wallet.SingleOrDefaultAsync(x => x.UserID == userId);
			Assert.NotNull(wallet);
			Assert.Equal(expectedBalance, wallet.Balance);
		}
	}
}
