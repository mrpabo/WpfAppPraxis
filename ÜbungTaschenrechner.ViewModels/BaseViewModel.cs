using System.ComponentModel;
using System.Reflection;   // Die Zeile using System.Reflection; importiert die Namespace System.Reflection, der eine Sammlung von Klassen enthält, die den Zugriff auf Metadateninformationen über die geladene ausführbare Anwendung ermöglichen. Zum Beispiel kann die Assembly-Klasse in dieser Namespace verwendet werden, um Informationen über die aktuell ausgeführte Assembly zu sammeln oder andere Assemblies zu laden und zu untersuchen.
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ÜbungTaschenrechner.ViewModels       // Die Klasse "BaseViewModel" ist eine abstrakte Klasse, die das "INotifyPropertyChanged" -Interface implementiert. Das Interface "INotifyPropertyChanged" bietet die Möglichkeit, andere Klassen darüber zu informieren, wenn sich eine Eigenschaft der aktuellen Klasse ändert.Die Klasse enthält ein Ereignis namens "PropertyChanged", das aufgerufen wird, wenn eine Eigenschaft der Klasse geändert wird.Es wird durch das Aufrufen der Methode "OnPropertyChanged" ausgelöst, die eine Zeichenfolge als Parameter annimmt.Die Zeichenfolge enthält den Namen der Eigenschaft, die geändert wurde.Die Methode "OnPropertyChanged" prüft, ob der Parameter propertyName einen Wert enthält.Wenn dies der Fall ist, ruft sie das Ereignis "PropertyChanged" auf, indem sie das "Invoke" -Keyword verwendet, das dem Ereignishandler mitteilt, dass es aufgerufen werden soll.Das "Invoke" -Keyword wird verwendet, um das Event aufzurufen, da es in einem anderen Thread aufgerufen werden kann. Das Ereignis "PropertyChanged" informiert andere Klassen darüber, dass sich eine Eigenschaft geändert hat, sodass sie die aktualisierten Werte abrufen können.
{
    public class BaseViewModel : INotifyPropertyChanged    // Die Klasse BaseViewModel implementiert das Interface INotifyPropertyChanged, welches es ermöglicht, Änderungen von Eigenschaften des ViewModel-Objekts an die View zu melden.

    {
        public event PropertyChangedEventHandler PropertyChanged;   // Das ist eine Ereignisdeklaration in C#. Das Ereignis "PropertyChanged" wird von der Klasse "BaseViewModel" deklariert und ist vom Typ "PropertyChangedEventHandler". Es ist ein Ereignis, das auftritt, wenn eine Eigenschaft in der Klasse geändert wird. Jeder, der diese Klasse verwendet, kann sich auf dieses Ereignis abonnieren, um benachrichtigt zu werden, wenn eine Eigenschaft geändert wurde. Die Benachrichtigung wird über die Handler-Methode "OnPropertyChanged" ausgelöst.
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")  // Die Methode OnPropertyChanged wird verwendet, um das PropertyChanged-Ereignis auszulösen, das vom INotifyPropertyChanged-Interface definiert wird. Das Ereignis wird ausgelöst, wenn eine Eigenschaft im ViewModel geändert wird, damit die Ansicht (View) aktualisiert werden kann.Die Methode enthält den Parameter[CallerMemberName] string propertyName = "", um den Namen der geänderten Eigenschaft automatisch zu erfassen, ohne ihn explizit anzugeben.Wenn dieser Parameter leer ist, wird der Name der aktuellen Methode(also der Eigenschaft) verwendet.Dadurch kann der Aufruf von OnPropertyChanged() in den ViewModel-Eigenschaften verkürzt werden, da kein Name der Eigenschaft als Argument übergeben werden muss.
    {
        if (!string.IsNullOrEmpty(propertyName))     // Dieser Code prüft, ob der Parameter propertyName nicht null oder eine leere Zeichenfolge ist. Wenn propertyName null oder eine leere Zeichenfolge ist, wird die Methode nicht ausgeführt.
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));     // Dieser Code löst das Ereignis PropertyChanged aus, das benachrichtigt, dass eine Eigenschaft des ViewModels geändert wurde. Das ? ist ein Nullbedingter Operatoren, der den Aufruf auf PropertyChanged vermeidet, wenn er null ist. Wenn das Ereignis ausgelöst wird, wird ein Objekt vom Typ PropertyChangedEventArgs übergeben, das den Namen der geänderten Eigenschaft enthält. Dadurch kann die Ansicht (View) das ViewModel benachrichtigen, wenn sich eine Eigenschaft ändert, auf die sie hört.
        }
    }
}

// Invoke ist eine Methode in der .NET Framework-Bibliothek, die es ermöglicht, eine Funktion oder Methode in einem anderen Thread auszuführen, der nicht der Haupt-Thread des Programms ist.
// Wenn eine Anwendung in einer Benutzeroberfläche läuft, wie z.B. einer WPF-Anwendung, blockiert der Haupt-Thread normalerweise, wenn eine lange andauernde Aufgabe ausgeführt wird,
// wie z.B. das Herunterladen einer Datei oder das Verarbeiten von Daten. Wenn die Anwendung währenddessen einfriert, wird dies als "Hängenbleiben" bezeichnet und kann ein schlechtes Benutzererlebnis verursachen.
// Durch Verwendung der Invoke-Methode kann eine Methode oder Funktion im Hintergrund-Thread ausgeführt werden, ohne dass der Haupt-Thread blockiert wird.
// Die Ergebnisse der Hintergrundaufgabe können dann über die Invoke-Methode an den Haupt-Thread zurückgegeben werden, um die Benutzeroberfläche zu aktualisieren oder andere notwendige Aufgaben auszuführen.

//Erklärung Assembly:

//Eine Assembly ist eine Sammlung von Typen und Ressourcen, die ein logisch zusammenhängendes Modul darstellen.
//Sie kann in verschiedenen Sprachen geschrieben und in einer Vielzahl von Anwendungen eingesetzt werden.
//Eine Assembly ist die grundlegende Einheit für die Bereitstellung von Code in .NET und enthält den ausführbaren Code sowie Metadaten, die vom Common Language Runtime (CLR) verwendet werden, um den Code zu laden, auszuführen, zu überwachen und zu sichern.
//Eine Assembly kann als DLL-Datei (Dynamic Link Library) oder als EXE-Datei (Executable) vorliegen.
