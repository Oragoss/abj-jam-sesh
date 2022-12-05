using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        //https://dennisse-pd.medium.com/how-to-create-a-cooldown-system-in-unity-4156f3a842ae????

        float fireRate = 2;
        float cooldownSeconds = 0.5f;
        float cooldown;
        int maxAmmo = 20;
        int ammo;
        float nextFire = 0.15f;

        // Use this for initialization
        void Start()
        {

        }

        void Update()
        {
            if (fireRate == 0 && Input.GetButtonDown("Fire1"))
            {   //Reduced to a single if, cause It does exactly the same
                //And in my Opinion, looks better. (You might want not to
                //in case you have anything else here that do needs the if)
                Debug.Log("Shoot();");
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire && fireRate > 0)
                {
                    //I added "&& fireRate > 0", because if not, this will run if the user decides
                    //to hold the button, as "GetButtonDown" only returns true the frame the button
                    //is pressed, and while its hold, is false, so the "else" will run, and so will this.
                    if (ammo > 0)
                    {   //If you have ammo
                        nextFire = Time.time + fireRate;
                        Debug.Log("Shoot();");
                        ammo--; //Explained by itself
                    }
                    if (ammo == 0)
                    {   //If you no longer have ammo
                        if (cooldown > Time.time)
                        {   //If there is no cooldown (relatively)
                            cooldown = Time.time + cooldownSeconds;
                        }
                    }
                }
            }

            if (Time.time > cooldown && ammo == 0)
            {   //If the cooldown is over, and you have no ammo cause else this will run kinda always,
                //as here we set the ammo to maxAmmo, and cooldown only happens when you run out
                //of ammo, then you will be constantly fulling the ammo.
                ammo = maxAmmo;
            }

        } //End of Update()
    }
}