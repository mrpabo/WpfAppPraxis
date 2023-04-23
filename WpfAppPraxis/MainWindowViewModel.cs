using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;     // Das System.Runtime.CompilerServices-Namespace enthält Typen, die für die Interaktion mit dem Compiler und für die Steuerung des Compiler-Verhaltens nützlich sind. Dazu gehören beispielsweise Attribute, die den Compiler anweisen, Code für bestimmte Funktionen zu generieren, oder Methoden, die von den Compiler generierten Code beeinflussen. Das Namespace enthält auch Typen für die Interaktion mit Features, die von der Common Language Runtime (CLR) bereitgestellt werden, wie beispielsweise der Garbage Collection oder dem Zugriff auf nicht verwalteten Code.
using System.Runtime.ConstrainedExecution;  // System.Runtime.ConstrainedExecution ist ein Namespace in .NET, der die Klasse ReliabilityContractAttribute enthält. Diese Klasse ermöglicht es Entwicklern, Verhaltensweisen anzugeben, die die Ausführung von Code beeinflussen sollen, indem sie Garantien in Bezug auf Zuverlässigkeit und Sicherheit bieten. Die Verwendung dieser Klasse kann dazu beitragen, sicherzustellen, dass bestimmte Codeabschnitte zuverlässig und sicher ausgeführt werden.
using System.Security.Cryptography;
using System.Windows.Data;        // Die System.Windows.Data-Namespace enthält Typen, die zum Binden von Daten an Steuerelemente und zur Manipulation von Daten verwendet werden können. Der Namespace enthält auch Typen, die zum Erstellen von benutzerdefinierten Bindungen verwendet werden können. Einige der häufig verwendeten Typen im Namespace sind Binding, BindingExpression, CollectionView, CollectionViewSource usw.
using System.Windows.Media;     //  Mit dieser Anweisung können Sie Klassen und Funktionen aus dem Namespace System.Windows.Media verwenden, ohne den vollqualifizierten Namen angeben zu müssen. Der Namespace System.Windows.Media enthält Typen, die die Verwendung von Medienelementen in WPF-Anwendungen ermöglichen. Dazu gehören z.B. Farben, Pinsel und Geometrien.
using System.Windows.Shapes;    // Das System.Windows.Shapes-Namespace enthält Typen für das Zeichnen von Formen, wie z.B. Rectangle, Ellipse, Line, Polygon, Polyline, Path und andere. Diese Typen können verwendet werden, um benutzerdefinierte Formen in einer WPF-Anwendung zu erstellen.
using System.Xml.Linq;

namespace WpfAppPraxis
{

    class MainWindowViewModel : INotifyPropertyChanged                   //Die Klasse MainWindowViewModel implementiert das INotifyPropertyChanged-Interface, welches die Änderungen von Eigenschaften der Klasse meldet, um eine Aktualisierung der Benutzeroberfläche zu ermöglichen.
    {

        public MainWindowViewModel()            // Die Klasse MainWindowViewModel hat einen Konstruktor, der beim Erstellen des Objekts aufgerufen wird. Im Konstruktor wird eine ClearCommand-Eigenschaft erstellt, die ein DelegateCommand ist.
                                                // Der DelegateCommand wird mit zwei Argumenten initialisiert: einer Bedingung, die bestimmt, ob der Befehl ausgeführt werden kann, und einem Befehl, der ausgeführt wird, wenn die Bedingung erfüllt ist.
                                                // In diesem Fall ist die Bedingung, dass sowohl Firstname als auch Lastname nicht leer sein dürfen.Der Befehl löscht dann die Werte von Firstname und Lastname.Nachdem der ClearCommand initialisiert wurde, werden Firstname und Lastname auf "Dave" und "Daven" gesetzt.
        {

            this.ClearCommand = new DelegateCommand(              //  DelegateCommand ist eine Klasse, die in WPF-Anwendungen verwendet wird, um eine Aktion (delegate) auszuführen, wenn eine Schaltfläche geklickt wird. In diesem Fall wird eine neue Instanz von DelegateCommand erstellt und der ClearCommand Eigenschaft der ViewModel-Klasse zugewiesen. Das erste Argument für den Konstruktor ist eine Bedingung, die angibt, ob der Befehl ausgeführt werden kann oder nicht. Wenn die Bedingung true ist, kann der Befehl ausgeführt werden. Das zweite Argument ist die Aktion, die ausgeführt wird, wenn der Befehl ausgeführt wird. In diesem Fall wird die Firstname und Lastname Eigenschaften der ViewModel-Klasse geleert, wenn der Befehl ausgeführt wird.
               (o) => !String.IsNullOrEmpty(Firstname) && !String.IsNullOrEmpty(Lastname),     // Dies definiert die Bedingung, unter der der Befehl "Clear" ausgeführt werden kann. Der Befehl kann ausgeführt werden, wenn sowohl der "Firstname"- als auch der "Lastname"-Wert nicht leer oder null sind.
               (o) => { this.Firstname = ""; this.Lastname = ""; }      // Dieser Codeabschnitt initialisiert das ClearCommand-Objekt mit einem neuen DelegateCommand-Objekt, das als Parameter zwei Lambda-Ausdrücke hat. Der erste Lambda-Ausdruck dient als Bedingung für die Ausführbarkeit des ClearCommand. In diesem Fall ist der Befehl ausführbar, wenn die Eigenschaften "Firstname" und "Lastname" nicht null oder leer sind. Der zweite Lambda-Ausdruck definiert die Aktion, die ausgeführt wird, wenn der Befehl ausgeführt wird. In diesem Fall wird der Wert der Eigenschaften "Firstname" und "Lastname" auf eine leere Zeichenfolge gesetzt.
             );
            Firstname = "Dave";         // Diese Zeilen setzen die Anfangswerte für die Firstname und Lastname Properties auf "Dave" und "Daven" beim Erstellen einer neuen Instanz des MainWindowViewModel.
            Lastname = "Daven";        


        }

        public DelegateCommand ClearCommand { get; set; }                   //Die Eigenschaft ClearCommand ist ein DelegateCommand, der zum Löschen der Textfelder verwendet wird. Ein DelegateCommand ist ein Befehlsobjekt, das auf eine Methode verweist, die ausgeführt wird, wenn der Befehl ausgeführt wird. In diesem Fall verweist der ClearCommand auf eine anonyme Methode, die zwei Bedingungen überprüft: dass Firstname und Lastname nicht leer sind.
                                                                            //Wenn die Bedingungen erfüllt sind, werden die Werte von Firstname und Lastname auf leere Zeichenfolgen gesetzt, um die Textfelder zu löschen. Die beiden letzten Zeilen des Konstruktors setzen Firstname und Lastname auf voreingestellte Werte ("Dave" und "Daven"), um die Textfelder beim Start der Anwendung vorzubelegen.

        string firstname;
        public string Firstname         // string firstname; definiert eine private Feldvariable namens firstname vom Typ string.
        {
            get => firstname;               //  Hier wird die Get- und Set-Methode für die Eigenschaft firstname definiert. Die Get-Methode gibt den Wert der Eigenschaft zurück, während die Set-Methode den Wert der Eigenschaft aktualisiert und das PropertyChanged-Event auslöst, wenn sich der Wert ändert. Wenn sich der Wert von firstname ändert, wird auch die Eigenschaft Fullname aktualisiert und das RaisePropertyChanged-Event ausgelöst, um die View über die Änderung zu benachrichtigen. Schließlich wird auch die RaiseCanExecuteChanged-Methode des ClearCommand-Objekts aufgerufen, um zu überprüfen, ob der Befehl ausgeführt werden kann oder nicht.
            set
            {
                if (firstname != value)     // Dies ist eine Bedingung, die überprüft, ob der neue Wert, der für das Attribut firstname gesetzt werden soll, tatsächlich anders ist als der aktuelle Wert. Wenn der neue Wert gleich dem aktuellen Wert ist, wird die Zuweisung übersprungen und es findet keine Aktualisierung statt.
                {
                    firstname = value;     // setzt den Wert der privaten Feldvariable firstname auf den neuen Wert, der als value-Parameter übergeben wurde.
                    this.RaisePropertyChanged();     //Die Methode RaisePropertyChanged() benachrichtigt die WPF-Bindungsinfrastruktur, dass sich eine Eigenschaft geändert hat und dass ein Refresh der UI erforderlich ist. Sie wird verwendet, um Änderungen an Eigenschaften zu melden, die von der Benutzeroberfläche gebunden sind.
                    this.RaisePropertyChanged(nameof(Fullname));  // Die RaisePropertyChanged-Methode wird in der set-Methode des Firstname-Properties aufgerufen, um anzuzeigen, dass sich der Wert des Firstname-Properties geändert hat. Dadurch werden alle Binding-Elemente, die an das Firstname-Property gebunden sind, aktualisiert.Das RaisePropertyChanged(nameof(Fullname)) ruft die RaisePropertyChanged - Methode auf, um anzuzeigen, dass sich der Wert des Fullname - Properties geändert hat. Dies ist erforderlich, da der Wert des Fullname - Properties vom Wert des Firstname-und Lastname - Properties abhängt.Durch das Aufrufen von RaisePropertyChanged(nameof(Fullname)) werden alle Binding - Elemente, die an das Fullname-Property gebunden sind, aktualisiert.
                    this.ClearCommand.RaiseCanExecuteChanged();  // Dieser Code-Abschnitt ruft die RaiseCanExecuteChanged-Methode auf dem ClearCommand auf, um zu signalisieren, dass sich der Zustand des Befehls geändert hat und neu ausgewertet werden muss, ob er ausgeführt werden kann oder nicht. Dies geschieht, wenn entweder der Vorname oder der Nachname des Benutzers geändert wird. Wenn beide Felder leer sind, kann der Befehl nicht ausgeführt werden, andernfalls kann er ausgeführt werden.


                    // Diese Methode implementiert den Getter und Setter für die Eigenschaft Firstname. Der Getter gibt den aktuellen Wert von firstname zurück,
                    // während der Setter den Wert von firstname auf den angegebenen Wert value setzt, sofern er sich von dem aktuellen Wert unterscheidet.
                    // Wenn sich firstname ändert, werden die Ereignisse PropertyChanged und PropertyChanged für die Eigenschaften "Firstname" und "Fullname" ausgelöst, indem die Methoden RaisePropertyChanged() aufgerufen werden.
                    // Diese Ereignisse werden von der WPF-Benutzeroberfläche abonniert, um Änderungen an den Eigenschaften anzuzeigen.
                    // Schließlich wird RaiseCanExecuteChanged() für das ClearCommand aufgerufen, um das Ausführen des ClearCommand zu ermöglichen oder zu deaktivieren, je nachdem, ob Firstname und Lastname leer oder nicht leer sind.


                }
            }

        }
        string lastname;        // In diesem Codeausschnitt wird eine private Instanzvariable lastname vom Typ string definiert. Diese Variable wird im Setter der öffentlichen Lastname-Eigenschaft verwendet, um den Wert der Eigenschaft zu speichern.
        public string Lastname      // Diese Klasse definiert eine Eigenschaft Lastname mit einem Getter und Setter. Wenn der Setter aufgerufen wird und das lastname Feld einen neuen Wert erhält, wird die RaisePropertyChanged Methode aufgerufen, um zu signalisieren, dass sich die Lastname Eigenschaft geändert hat. Ebenso wird die Fullname Eigenschaft aktualisiert, da sich diese aus Firstname und Lastname zusammensetzt.

        {
            get => lastname;      // Dies ist der Getter der Eigenschaft Lastname, der den aktuellen Wert der privaten Feldvariable lastname zurückgibt.
            set                   // Das set Schlüsselwort wird verwendet, um einen Wert einer Eigenschaft festzulegen. In diesem Fall wird es verwendet, um den Wert der Lastname-Eigenschaft festzulegen, wenn eine Zuweisung vorgenommen wird.
            {
                if (lastname != value)    // Dieser Code prüft, ob der neue Wert, der an das Lastname-Property gebunden ist, nicht gleich dem aktuellen Wert lastname ist. Wenn die Bedingung wahr ist, wird der neue Wert in lastname zugewiesen und die Methode RaisePropertyChanged wird aufgerufen, um zu signalisieren, dass sich das Property geändert hat und dass alle an dieses Property gebundenen UI-Elemente aktualisiert werden müssen. Außerdem wird das Fullname-Property aktualisiert, da es sowohl von Firstname als auch von Lastname abhängt.
                {
                    lastname = value;      // Das Setzen der Eigenschaft wird durch die Zuweisung des neuen Werts 'value' an die Instanzvariable 'lastname' ausgeführt. Dadurch wird der neue Wert in der Klasse gespeichert und kann später abgerufen werden.
                    this.RaisePropertyChanged();    // this.RaisePropertyChanged() benachrichtigt alle registrierten Event-Handler, dass sich die Eigenschaft geändert hat, auf die sich das Ereignis bezieht. In diesem Fall wird das Ereignis PropertyChanged ausgelöst, um zu signalisieren, dass sich der Wert der Lastname-Eigenschaft geändert hat. Dies ist wichtig, damit alle UI-Elemente, die diese Eigenschaft binden, aktualisiert werden können.
                    this.RaisePropertyChanged(nameof(Fullname));  // Die RaisePropertyChanged-Methode wird aufgerufen, um das ViewModel zu benachrichtigen, dass sich der Wert der Lastname-Eigenschaft geändert hat. Dadurch wird ein Ereignis ausgelöst, das an die Ansicht gebunden ist, die das ViewModel nutzt. Dadurch kann die Ansicht die Änderung der Lastname-Eigenschaft verarbeiten und aktualisiert sich entsprechend, um den neuen Wert anzuzeigen. Das nameof(Fullname)-Ausdruck gibt den Namen der Fullname-Eigenschaft als Zeichenfolge zurück, um das ViewModel darüber zu informieren, dass sich auch der Wert der Fullname-Eigenschaft geändert hat.


                }
            }

        }



        //public string Firstname { get; set; }
        //public string Lastname { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";       // Die Eigenschaft Fullname ist eine berechnete Eigenschaft und gibt die Verkettung von Firstname und Lastname zurück, um den vollständigen Namen darzustellen. Dies wird durch die Verwendung einer Expression-Bodied-Eigenschaft und einer Interpolationszeichenfolge erreicht. Der Compiler wandelt dies in eine Getter-Methode um, die die Firstname- und Lastname-Felder kombiniert und als Ergebnis zurückgibt.

        public event PropertyChangedEventHandler PropertyChanged;      // Ereignis, das aufgerufen wird, wenn sich eine Eigenschaft des Objekts ändert. Es ist ein Teil des INotifyPropertyChanged-Interfaces und wird verwendet, um Binding in WPF-Anwendungen zu implementieren. Wenn eine Eigenschaft aktualisiert wird, wird das Ereignis ausgelöst und die UI wird benachrichtigt, um die Änderungen darzustellen.



        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")     //Die Methode RaisePropertyChanged wird verwendet, um das Ereignis PropertyChanged auszulösen, wenn eine Eigenschaft im ViewModel geändert wird. Dies wird normalerweise verwendet, um der View mitzuteilen, dass sich eine bestimmte Eigenschaft geändert hat und dass die View die Änderung aktualisieren sollte.Die RaisePropertyChanged-Methode akzeptiert einen optionalen Parameter propertyName, der den Namen der Eigenschaft enthält, die geändert wurde.Dieser Parameter wird in der Regel automatisch vom Compiler gesetzt, wenn die Methode im Kontext einer Eigenschaft aufgerufen wird, und gibt den Namen der Eigenschaft an, die geändert wurde.Wenn kein propertyName-Parameter angegeben ist, wird der Name der aufrufenden Eigenschaft als Standardwert verwendet.Insgesamt ist die RaisePropertyChanged-Methode ein wichtiger Bestandteil des INotifyPropertyChanged-Interfaces und wird in vielen ViewModel-Implementierungen verwendet, um die Views auf Änderungen im ViewModel zu aktualisieren.
        {
            if (!string.IsNullOrEmpty(propertyName))   // Diese Zeile prüft, ob der Name der geänderten Eigenschaft propertyName nicht leer oder Null ist, bevor das PropertyChanged Ereignis ausgelöst wird. Der CallerMemberName-Attribut ermöglicht es, den Namen der aufgerufenen Methode automatisch als propertyName zu übergeben, falls dieser nicht explizit angegeben wurde. Wenn das Ereignis ausgelöst wird, wird die PropertyChangedEventHandler-Delegatenliste mit dem Sender (in diesem Fall this, also die aktuelle Instanz der MainWindowViewModel-Klasse) und einem PropertyChangedEventArgs-Objekt aufgerufen, das den Namen der geänderten Eigenschaft enthält (propertyName).
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));   //  prüft, ob der übergebene propertyName-Parameter leer oder null ist. Wenn nicht, wird das PropertyChanged-Ereignis ausgelöst, indem es mit dem this-Objekt als Sender und einer neuen Instanz von PropertyChangedEventArgs initialisiert wird, die den Namen der geänderten Eigenschaft enthält. Der ?.-Operator wird verwendet, um sicherzustellen, dass das PropertyChanged-Ereignis nur ausgelöst wird, wenn mindestens ein Abonnent vorhanden ist, um eine NullReferenceException zu vermeiden.
        }
    }

















}
