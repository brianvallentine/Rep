using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1 : QueryBasis<M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FUNDOCOMISVA
            (CODPRODU ,
            NRCERTIF ,
            NRPROPAZ ,
            NUM_TERMO,
            SITUACAO ,
            CODOPER ,
            FONTE ,
            AGENCIA ,
            CODCLIEN ,
            NRMATRVEN,
            VLBASVG ,
            VALBASAP ,
            VLCOMISVG,
            VLCOMISAP,
            DTQITBCO ,
            PCCOMIND ,
            PCCOMGER ,
            PCCOMSUP ,
            DTMOVTO ,
            COD_USUARIO,
            TIMESTAMP)
            VALUES (:PROPVA-CODPRODU,
            :PROPVA-NRCERTIF,
            0,
            0,
            '0' ,
            1101,
            :PROPVA-FONTE,
            :PROPVA-AGECOBR,
            :PROPVA-CODCLIEN,
            :PROPVA-NRMATRVEN,
            :FUNDO-VALBASVG,
            :FUNDO-VALBASAP,
            :FUNDO-VLCOMISVG,
            :FUNDO-VLCOMISAP,
            :PROPVA-DTQITBCO,
            :FUNDO-PCCOMIND,
            :FUNDO-PCCOMGER,
            :FUNDO-PCCOMSUP,
            :SISTEMA-DTMOVABE,
            'VA0118B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP) VALUES ({FieldThreatment(this.PROPVA_CODPRODU)}, {FieldThreatment(this.PROPVA_NRCERTIF)}, 0, 0, '0' , 1101, {FieldThreatment(this.PROPVA_FONTE)}, {FieldThreatment(this.PROPVA_AGECOBR)}, {FieldThreatment(this.PROPVA_CODCLIEN)}, {FieldThreatment(this.PROPVA_NRMATRVEN)}, {FieldThreatment(this.FUNDO_VALBASVG)}, {FieldThreatment(this.FUNDO_VALBASAP)}, {FieldThreatment(this.FUNDO_VLCOMISVG)}, {FieldThreatment(this.FUNDO_VLCOMISAP)}, {FieldThreatment(this.PROPVA_DTQITBCO)}, {FieldThreatment(this.FUNDO_PCCOMIND)}, {FieldThreatment(this.FUNDO_PCCOMGER)}, {FieldThreatment(this.FUNDO_PCCOMSUP)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 'VA0118B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPVA_CODPRODU { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string PROPVA_AGECOBR { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_NRMATRVEN { get; set; }
        public string FUNDO_VALBASVG { get; set; }
        public string FUNDO_VALBASAP { get; set; }
        public string FUNDO_VLCOMISVG { get; set; }
        public string FUNDO_VLCOMISAP { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string FUNDO_PCCOMIND { get; set; }
        public string FUNDO_PCCOMGER { get; set; }
        public string FUNDO_PCCOMSUP { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static void Execute(M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1 m_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1)
        {
            var ths = m_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}