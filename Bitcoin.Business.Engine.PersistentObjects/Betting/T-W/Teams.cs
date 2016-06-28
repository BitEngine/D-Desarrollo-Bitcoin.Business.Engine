using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitcoin.Business.Engine.PersistentObjects.NonPersistent;
using DevExpress.Xpo;
using Bitcoin.Business.Engine.PersistentObjects.Betting.A_D;

namespace Bitcoin.Business.Engine.PersistentObjects.Betting.T_W
{
    /// <summary>
    /// Clase que representa los equipos 
    /// involucrados en una competencia
    /// </summary>
    public class Teams : NonPersistentEntity
    {
        /// <summary>
        /// Nombre del equipo
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { SetPropertyValue<string>("Name", ref name, value); }
        }

        /// <summary>
        /// Equipo que son asociados a una definición de predicción
        /// grupo
        /// </summary>
        private DefinitionPhaseBets definitionPhaseBet;
        [Association("DefinitionPhaseBets-Teams")]
        public DefinitionPhaseBets DefinitionPhaseBet
        {
            get { return definitionPhaseBet; }
            set { SetPropertyValue<DefinitionPhaseBets>("DefinitionPhaseBet", ref definitionPhaseBet, value); }
        }

        public Teams(Session session) : base(session) { }       
        public override void AfterConstruction() { base.AfterConstruction(); }
    }
}
