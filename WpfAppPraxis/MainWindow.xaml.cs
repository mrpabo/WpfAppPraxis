using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;  // Dies ist eine Anweisung, die dem Compiler mitteilt, dass der Code, der für die Erzeugung von Typen, Methoden usw. zur Laufzeit verwendet wird, im Namespace System.Reflection.Emit gefunden werden kann. Die Klasse AssemblyBuilder, die in diesem Namespace gefunden wird, wird oft verwendet, um dynamische Assemblys zur Laufzeit zu erstellen.
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;  // Die System.Windows.Navigation Namespace in der .NET Framework-Klassenbibliothek stellt Klassen für die Navigation innerhalb einer Anwendung bereit. Mit diesen Klassen können Sie Benutzereingaben verwalten, Benutzeroberflächen erstellen und Navigationselemente wie Schaltflächen hinzufügen. Die wichtigste Klasse in diesem Namespace ist die NavigationService-Klasse, die die Hauptnavigation innerhalb einer Anwendung verwaltet.
using System.Windows.Shapes;

namespace WpfAppPraxis    //  Hauptfensteransicht (MainWindow) einer WPF-Desktopanwendung.
                          //  Der Code definiert eine Klasse namens MainWindow, die von der Window-Klasse erbt und das Hauptfenster der Anwendung repräsentiert.
                          //  Im Konstruktor der Klasse wird InitializeComponent() aufgerufen, um die XAML-Datei zu laden und das Fenster zu initialisieren.
                          //  Anschließend wird das DataContext-Property auf eine neue Instanz der MainWindowViewModel-Klasse gesetzt, um das Datenbindungsziel für die Benutzeroberfläche festzulegen
                          //  .Es gibt auch drei Event-Handler-Methoden: TextBox_TextChanged, TextBox_TextChanged_1 und Button_Click.Diese sind jedoch derzeit leer und haben keinen Code.
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window   // Die Klasse "MainWindow" ist eine Teilklasse der "Window"-Klasse und repräsentiert das Hauptfenster der WPF-Anwendung. Das "partial"-Schlüsselwort bedeutet, dass die Klasse in mehrere Dateien aufgeteilt sein kann und dennoch als eine Klasse betrachtet wird.
                                               // Im Konstruktor der Klasse wird das Hauptfenster initialisiert und dem Fenster wird eine Instanz des MainWindowViewModel als DataContext zugewiesen.Die drei Methoden "TextBox_TextChanged", "TextBox_TextChanged_1" und "Button_Click" sind Ereignishandler-Methoden, die aufgerufen werden, wenn bestimmte Ereignisse (z.B.das Klicken auf einen Button) im MainWindow auftreten.
    {
        public MainWindow()   // Dies ist der Konstruktor der MainWindow Klasse, der beim Erstellen des Fensters aufgerufen wird. Hier wird das Fenster initialisiert und dem DataContext des Fensters eine neue Instanz des MainWindowViewModel zugewiesen. Der DataContext wird verwendet, um Daten an die Benutzeroberfläche (XAML) zu binden, so dass sie angezeigt und bearbeitet werden können.
        {
            InitializeComponent(); // Die InitializeComponent()-Methode ist eine Methode, die von Visual Studio generiert wird, wenn Sie eine WPF-Anwendung mit dem visuellen Designer erstellen. Sie erstellt das visuelle Layout der Benutzeroberfläche und verbindet die Ereignishandler mit den Steuerelementen. Diese Methode wird normalerweise in den Konstruktoren von Fenstern und Benutzersteuerelementen aufgerufen, um sicherzustellen, dass die Benutzeroberfläche beim Starten der Anwendung korrekt initialisiert wird.
            this.DataContext = new MainWindowViewModel();  // Hier wird die DataContext-Eigenschaft des MainWindow auf eine neue Instanz der MainWindowViewModel-Klasse gesetzt. Dadurch können die in der ViewModel-Klasse definierten Eigenschaften und Methoden von den XAML-Elementen in der MainWindow verwendet werden. Zum Beispiel können Daten von der View an das ViewModel gebunden werden, um diese zu verarbeiten oder zu speichern.
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)   // Dies ist ein Ereignishandler, der aufgerufen wird, wenn der Text in einem Textfeld geändert wird. Der TextChangedEventArgs-Parameter enthält Informationen über die Änderung, einschließlich des ursprünglichen Texts, des neuen Texts und der Position, an der die Änderung stattgefunden hat. In diesem Fall wird der Code des Ereignishandlers nicht ausgeführt, da er leer ist. Es ist jedoch üblich, Ereignishandler zu implementieren, um auf Benutzereingaben zu reagieren.
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)  // Diese Methode wird aufgerufen, wenn sich der Text im zweiten Textfeld ändert. Da das zweite Textfeld nur zur Anzeige des Ergebnisses verwendet wird, ist diese Methode leer und hat keinen Code.
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)  // Das ist eine leere Methode, die aufgerufen wird, wenn der Benutzer auf einen Button in der MainWindow klickt. Derzeit führt sie keine Aktion aus und der Code innerhalb der Methode ist leer.
        {

        }
    }
}
