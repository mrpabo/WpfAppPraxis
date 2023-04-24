using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Shapes;


// Dieser Code definiert eine benutzerdefinierte Klasse "DelegateCommand", die das .NET Framework-Interface "ICommand" implementiert.
// Die Klasse ermöglicht es, Aktionen (execute) und Bedingungen (canExecute) als Delegaten (Action, Predicate) zu übergeben, um die Ausführung von Befehlen zu steuern.
// Es gibt zwei Konstruktoren: Einer erwartet einen Delegaten zur Überprüfung, ob der Befehl ausgeführt werden kann
// (canExecute) und einen Delegaten zur Ausführung des Befehls (execute). Der andere Konstruktor erwartet nur den Delegaten zur Ausführung des Befehls,
// wobei standardmäßig angenommen wird, dass der Befehl immer ausgeführt werden kann.Die Klasse hat eine "CanExecuteChanged"-Ereignis, das aufgerufen wird, wenn sich der Zustand des Befehls ändert.
// Die Methode "RaiseCanExecuteChanged" wird verwendet, um das Ereignis aufzurufen.Die Methode "CanExecute" überprüft, ob der Befehl ausgeführt werden kann, indem sie den "canExecute"-Delegaten aufruft.
// Wenn kein Delegat angegeben wurde, wird standardmäßig angenommen, dass der Befehl ausgeführt werden kann.Die Methode "Execute" ruft den "execute"-Delegaten auf, um den Befehl auszuführen.

namespace WpfAppPraxis
{
    internal class DelegateCommand : ICommand  // DelegateCommand ist eine Klasse, die das ICommand-Interface implementiert. Dieses Interface definiert Methoden, die von einer Befehlsquelle wie z.B. einem Button verwendet werden, um Aktionen in der Anwendung auszuführen. DelegateCommand bietet eine Möglichkeit, eine Aktion zu definieren, die ausgeführt wird, wenn der Befehl ausgeführt wird, und eine Bedingung anzugeben, unter der der Befehl ausgeführt werden kann. Wenn die Bedingung nicht erfüllt ist, ist der Befehl deaktiviert und kann nicht ausgeführt werden.
    {
        readonly Action<object> execute;    // Dies ist eine private Feldvariable vom Typ "Action<object>", die verwendet wird, um eine Aktion auszuführen, wenn das DelegateCommand ausgeführt wird. Die Variable ist als schreibgeschützt deklariert, da sie nur im Konstruktor initialisiert und nicht nachträglich geändert wird. Das bedeutet, dass die Aktion, die beim Erstellen des DelegateCommand-Objekts angegeben wird, während der gesamten Lebensdauer des Objekts ausgeführt wird.
        readonly Predicate<object> canExecute;  // Dies ist eine private readonly Feldvariable vom Typ Predicate<object>, die eine Methode referenziert, welche einen Parameter vom Typ object akzeptiert und einen boolschen Wert zurückgibt. Diese Variable wird genutzt, um zu überprüfen, ob das Kommando ausgeführt werden kann oder nicht.

        public DelegateCommand( Predicate<object> canExecute, Action<object> execute) =>   // Dieser Konstruktor der DelegateCommand-Klasse initialisiert eine neue Instanz der DelegateCommand-Klasse. Der Konstruktor erhält zwei Parameter: canExecute und execute. canExecute ist eine Funktion, die einen Parameter vom Typ object entgegennimmt und ein Boolean zurückgibt, der angibt, ob das Command ausgeführt werden kann oder nicht. execute ist eine Action, die einen Parameter vom Typ object entgegennimmt und das Command ausführt.
            (this.canExecute, this.execute) = (canExecute, execute);    // In diesem Konstruktor wird der execute-Parameter dem execute-Feld der DelegateCommand-Klasse zugewiesen und der canExecute-Parameter dem canExecute-Feld der DelegateCommand-Klasse zugewiesen.Dies wird mit einer Tupelzuweisung erreicht.
        public DelegateCommand(Action<object> execute) : this(null, execute){ }  // Diese Zeile ist ein weiterer Konstruktor für die DelegateCommand Klasse, der nur einen Parameter execute akzeptiert. In diesem Konstruktor wird der canExecute-Parameter standardmäßig auf null gesetzt, da dieser Parameter optional ist und in einigen Fällen nicht benötigt wird. Hier wird der canExecute-Parameter auf null gesetzt und der execute-Parameter auf den übergebenen Wert gesetzt, indem der erste Konstruktor mit null als erstem Parameter aufgerufen wird.


        public event EventHandler CanExecuteChanged;   // Dies ist eine Ereignisdeklaration für das CanExecuteChanged-Ereignis. Wenn dieser Delegat aufgerufen wird, bedeutet dies, dass der Rückgabewert der CanExecute-Methode geändert hat. Dadurch kann das Steuerelement, das an das ICommand gebunden ist, den CanExecute-Status aktualisieren und entscheiden, ob der Befehl ausführbar ist oder nicht.

        public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);   // Die Methode RaiseCanExecuteChanged ist dafür da, um das CanExecuteChanged-Event auszulösen, welches von der ICommand-Schnittstelle definiert wird.
                                                                                                         // Das Event wird normalerweise von der UI ausgelöst, wenn sich die Eingabe des Benutzers ändert und dadurch die Bedingungen für die Ausführbarkeit der ICommand geändert werden.Mit der RaiseCanExecuteChanged-Methode kann das Event manuell ausgelöst werden, um die UI über eine Änderung des Ausführungszustands der ICommand zu informieren.In diesem Fall wird die Methode aufgerufen, wenn sich der Zustand der ICommand ändert, sodass die CanExecute-Methode geändert werden muss. Die RaiseCanExecuteChanged-Methode ruft das CanExecuteChanged-Event auf, wodurch die UI aktualisiert wird und die Bedingungen für die Ausführbarkeit der ICommand überprüft werden.

        public bool CanExecute(object parameter) => this.canExecute?.Invoke(parameter) ?? true;   // Die Methode CanExecute überprüft, ob der Befehl ausgeführt werden kann. Das Ergebnis wird als boolescher Wert zurückgegeben. Wenn das canExecute-Feld nicht null ist, wird der angegebene Parameter an das canExecute-Feld übergeben, das einen booleschen Wert zurückgibt. Wenn das Ergebnis null ist, wird der Standardwert true zurückgegeben, was bedeutet, dass der Befehl standardmäßig ausgeführt werden kann.
        public void Execute(object parameter) => this.execute?.Invoke(parameter);  // Dies ist die Implementierung der Execute-Methode der ICommand-Schnittstelle. Wenn der Command ausgeführt wird, wird der execute-Delegate aufgerufen, der eine Aktion ausführt, die im Konstruktor des DelegateCommand-Objekts definiert wurde. Der Parameter, der an die Execute-Methode übergeben wird, wird an die execute-Aktion weitergeleitet. Wenn das execute-Delegate nicht definiert wurde (null), wird die Execute-Methode einfach beendet, ohne irgendetwas auszuführen.



    }
}
