using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ÜbungTaschenrechner.Entities     //Dieser Code definiert eine Basisklasse für Modelle, die die INotifyPropertyChanged-Schnittstelle implementiert, um Änderungen an Eigenschaften zu verfolgen und anzuzeigen.
                                           //Die Klasse hat eine geschützte virtuelle Methode, die bei einer Eigenschaftsänderung aufgerufen wird und einen optionalen Parameter für den Namen der geänderten Eigenschaft hat.
                                           //Diese Methode ruft das Ereignis PropertyChanged auf, das anzeigt, dass eine Eigenschaft geändert wurde und den Namen der geänderten Eigenschaft als Parameter enthält.
{
    public class ModelBase : INotifyPropertyChanged     // Die ModelBase-Klasse implementiert das INotifyPropertyChanged-Interface und stellt eine Methode namens OnPropertyChanged bereit, um den Code zu vereinfachen, der das Ereignis auslöst, wenn sich eine Eigenschaft in der Klasse ändert. Dadurch können andere Teile der Anwendung, die an diesen Änderungen interessiert sind, automatisch benachrichtigt werden, ohne dass manuelle Aktualisierungen erforderlich sind.
    {
        public event PropertyChangedEventHandler PropertyChanged;  // Klasse ModelBase implementiert das INotifyPropertyChanged-Interface, um anderen Teilen der Anwendung mitzuteilen, dass sich Eigenschaften eines Objekts geändert haben.Durch das Definieren des PropertyChanged-Events wird sichergestellt, dass diese Benachrichtigung stattfindet, sobald eine Eigenschaft geändert wird.Dadurch können zum Beispiel grafische Elemente in der Benutzeroberfläche automatisch aktualisiert werden, wenn sich die Daten ändern, die sie darstellen.

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")       // Diese Methode wird aufgerufen, um das PropertyChanged-Event auszulösen. Sie akzeptiert den Namen der geänderten Eigenschaft als optionalen Parameter (mithilfe von CallerMemberName-Attribut kann der Parameter aus dem Namen des Aufrufers bestimmt werden) und löst das PropertyChanged-Event aus, um andere Teile der Anwendung zu benachrichtigen, dass sich eine Eigenschaft geändert hat. Die Methode ist virtual, damit sie von abgeleiteten Klassen überschrieben werden kann, um das Verhalten zu ändern, wenn eine Eigenschaft geändert wird.
        {
            if (!string.IsNullOrEmpty(propertyName))      // Dies ist eine Bedingung, um sicherzustellen, dass der Name der Eigenschaft, die geändert wurde, nicht leer ist, bevor die PropertyChanged-Event aufgerufen wird. Wenn der Name der Eigenschaft leer oder null ist, wird die Event nicht aufgerufen, da es keine Eigenschaft gibt, die geändert wurde.
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));    // Dieser Code ruft das PropertyChanged-Event auf, das in der ModelBase-Klasse definiert wurde. Wenn ein Benutzer eine Eigenschaft ändert, wird die Methode OnPropertyChanged() aufgerufen, um das Ereignis auszulösen und andere Teile der Anwendung über die Änderung zu informieren. this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); löst das Ereignis aus und übergibt den Namen der geänderten Eigenschaft als Parameter. Das Fragezeichen in this.PropertyChanged?.Invoke() stellt sicher, dass das Ereignis nur ausgelöst wird, wenn das PropertyChanged-Event nicht null ist.
        }
    }
}
