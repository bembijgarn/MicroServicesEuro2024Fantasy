namespace Euro2024Stat.Web.Models
{
    public class CountyGroupsViewModel
    {
        public List<Countrydto> GroupA { get; set; }
        public List<Countrydto> GroupB { get; set; }
        public List<Countrydto> GroupC { get; set; }
        public List<Countrydto> GroupD { get; set; }
        public List<Countrydto> GroupE { get; set; }
        public List<Countrydto> GroupF { get; set; }


        public CountyGroupsViewModel(List<Countrydto> a, List<Countrydto> b, List<Countrydto> c, List<Countrydto> d, List<Countrydto> e, List<Countrydto> f)
        {
            this.GroupA = a;
            this.GroupB = b;
            this.GroupC = c;
            this.GroupD = d;
            this.GroupE = e;               
            this.GroupF = f;
        }
    }
}
