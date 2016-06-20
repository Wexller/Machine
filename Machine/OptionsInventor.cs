using System;
using Inventor;

namespace Machine
{
    /// <summary>
    /// С помощью класса получаются сведенья об Inventor. И устанавливается соединение с Inventor 
    /// </summary>
    public class OptionsInventor
    {

        #region Fields

        /// <summary>
        /// Переменная, хранящая ссылку на новый документ, созданный с использованием стандартного шаблона
        /// </summary>
        private PartDocument _partDocument = default(PartDocument);

        /// <summary>
        /// Переменная, хранящая ссылку на программный "обозреватель" текущего проекта  
        /// </summary>
        private PartComponentDefinition _compDefinition = default(PartComponentDefinition);

        /// <summary>
        /// Переменная, хранящая ссылку на Inventor
        /// </summary>
        private Inventor.Application _thisApplication;

        #endregion

        #region Methods

        /// <summary>
        /// Метод выполняющий инициализацию инвентора.
        /// </summary>
        /// <exception cref="ThisApplication">Inventor не был включен перед запуском плагина</exception>
        public OptionsInventor()
        {

            Inventor.Application thisApplication = null;
            try
            {
                thisApplication = (Inventor.Application)
                System.Runtime.InteropServices.Marshal.
                GetActiveObject("Inventor.Application");
                //Создание проекта
                _partDocument = (PartDocument)thisApplication.Documents.Add(DocumentTypeEnum.kPartDocumentObject,
                 thisApplication.FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject));
                _compDefinition = _partDocument.ComponentDefinition;
                this._thisApplication = thisApplication;
            }
            catch
            {
                throw new Exception(@"Перед запуском приложения необходимо запустить Inventor");
            }

        }

        /// <summary>
        /// Метод, создающий проект
        /// </summary>
        public void OptionsPublic()
        {
            Inventor.Application thisApplication = null;
            thisApplication = (Inventor.Application)
               System.Runtime.InteropServices.Marshal.
               GetActiveObject("Inventor.Application");
            //Создание проекта
            _partDocument = (PartDocument)thisApplication.Documents.Add(DocumentTypeEnum.kPartDocumentObject,
             thisApplication.FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject));
            _compDefinition = _partDocument.ComponentDefinition;
            this._thisApplication = thisApplication;
        }

        /// <summary>
        /// Метод возвращающий ссылку на "обозреватель".
        /// </summary>
        /// <returns>_compDefinition</returns>
        public PartComponentDefinition CompDefenition()
        {
            return _compDefinition;
        }

        /// <summary>
        /// Метод возвращающий ссылку на Inventor.
        /// </summary>
        /// <returns>_thisApplication</returns>
        public Inventor.Application ThisApplication()
        {
            return _thisApplication;
        }

        #endregion

    }
}
