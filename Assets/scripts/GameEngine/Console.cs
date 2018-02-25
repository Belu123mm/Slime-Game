 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Acordate de esto

public class Console : MonoBehaviour {
    //Esta es la clase que maneja la consola. 
    //Se debe usar RegisterCommand para registrar el nombre del comando y la funcion
    //Las funciones deben crearse abajo, usando funciones de scripts
    //El WriteInCOnsole escribe algo en consola
    //El Testconsolewithreturn testconsolewithoutreturn son funciones de testeo de consola
    public static Console instance;

    public delegate void FunctionPrototype();
    public FunctionPrototype functionPrototype;
    public Dictionary<string, FunctionPrototype> allCommands = new Dictionary<string, FunctionPrototype>();

    public Text backgroundText;
    public InputField inputText;
    public Scrollbar scrollball;

    public KeyCode keyForOpenCloseConsole;

    public GameObject consoleContent;



    void Start() {

        functionPrototype = Start;
        consoleContent = this.transform.FindChild("content").gameObject;

        //Registro de comandos
        RegisterCommand("test with return", testConsoleWithReturn);
        RegisterCommand("test without return", testConsoleWithoutReturn);
        RegisterCommand("normal bullet", normalShoot);
        RegisterCommand("big bullet", bigShoot);
        RegisterCommand("quick bullet", quickShoot);
        RegisterCommand("triple bullet", tripleShoot);
        RegisterCommand("Ultra life", ultraLife);
        RegisterCommand("circle bullet", circleShoot);
    }

    void Update() {
        scrollball.value = 0;

        if ( Input.GetKeyDown(keyForOpenCloseConsole) )
            consoleContent.SetActive(!consoleContent.activeSelf);
        if ( consoleContent.activeSelf && Input.GetKeyDown(KeyCode.Return) ) {
            string commandName = inputText.text;

            if ( allCommands.ContainsKey(commandName) )
                allCommands [ inputText.text ].Invoke();
            else
                WriteInConsole("This command doesn't exist");
        }
    }

    //Registro
    public void RegisterCommand( string name, FunctionPrototype command ) {
        allCommands [ name ] = command;
    }

    //Devolucion
    public void WriteInConsole( string txt ) {
        backgroundText.text += txt + "\n";
    }

    //Funciones 
    public void testConsoleWithoutReturn()//Cree este comando para testear la consola
    {
        print("endtest");
    }
    public void testConsoleWithReturn()//Cree esta funcion para que haga algo y devuelva algo a la consola
    {
        print("endtest");
        WriteInConsole("endtest");
    }

    public void ultraLife() {
        //slimeScript.vida = 10000000000000000;
        WriteInConsole("Life set to over 9000");
    }
    public void normalShoot() {
        FindObjectOfType<slimeScript>().currentBulletName = BULLETTYPES.normal;
        WriteInConsole("bullet set to normal");
    }
    public void bigShoot() {
        FindObjectOfType<slimeScript>().currentBulletName = BULLETTYPES.big;
        WriteInConsole("bullet set to big");

    }
    public void quickShoot() {
        FindObjectOfType<slimeScript>().currentBulletName = BULLETTYPES.quick;
        WriteInConsole("bullet set to quick");

    }
    public void tripleShoot() {
        FindObjectOfType<slimeScript>().currentBulletName = BULLETTYPES.normal;
        WriteInConsole("bullet set to triple");

    }
    public void circleShoot() {
        FindObjectOfType<slimeScript>().currentBulletName = BULLETTYPES.spine;
        WriteInConsole("bullet set to circle");

    }

}
