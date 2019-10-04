namespace WebThing.Models
{
    public class NinjaTurtle
    {
        public static NinjaTurtle[] MainTurtles
        {
            get
            {
                return new NinjaTurtle[]
                {
                    new NinjaTurtle()
                    {
                        Name = "Leonardo",
                        Color = "Blue",
                        Weapon = "Katana",
                        Skill = "Leads",
                        ImgPath = "img/leonardo.png"
                    },
                    new NinjaTurtle()
                    {
                        Name = "Donatello",
                        Color = "Purple",
                        Weapon = "Bow-Staff",
                        Skill = "does Machines",
                        ImgPath = "img/donatello.png"
                    },
                    new NinjaTurtle()
                    {
                        Name = "Raphael",
                        Color = "Red",
                        Weapon = "Sai",
                        Skill = "is Cool but Crude",
                        ImgPath = "img/raphael.png"
                    },
                    new NinjaTurtle()
                    {
                        Name = "Michelangelo",
                        Color = "Orange",
                        Weapon = "Nunchucks",
                        Skill = "is a Party Dude",
                        ImgPath = "img/michelangelo.png"
                    },
                };
            }
        }
        public string Name {get;set;}
        public string Color {get;set;}
        public string Weapon {get;set;}
        public string Skill {get;set;}
        public string ImgPath {get;set;}
    }
}