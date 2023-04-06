using BridgePattern.Model.Interface;
using BridgePattern.Realization.Class;
using BridgePattern.Realization.Interface;


ICreateble? createble = null;
IPlayable? playable = null;
ICharacther characther = null;
IWeapon Weapon = null;
int choice = 1;

while (choice > 0)
{
    Console.WriteLine
    ("Что вы хотите? " +
    "\n1.Создать персонажа" +
    "\n2.Создать оружие" +
    "\n0.Выйти");

     choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            createble = new CreateChar();

            Console.WriteLine("1.Создать  играбельного \n2.Cоздать НПС");
            int choice2 = int.Parse(Console.ReadLine());

            switch (choice2)
            {
                case 1:
                    playable = ((CreateChar)createble).CreatePlayebleCharacther();
                    Console.WriteLine(playable);
                    break;

                case 2:
                    characther = ((CreateChar)createble).CreateCharacther();
                    Console.WriteLine(characther);
                    break;
            }

            break;

        case 2:
            createble = new CreateWeapon();
            Weapon = ((CreateWeapon)createble).CreateNewWeapon();
            break;

    }

    Console.Clear();
}
if(Weapon != null && playable != null)
{
    playable.SetWeapon(Weapon);
} 
