using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0152B
{
    public class M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1 : QueryBasis<M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1>
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
            VALUES (:CODPRODU,
            :NRCERTIF,
            0,
            0,
            '0' ,
            1103,
            :FONTE,
            :AGENCIA,
            :CODCLIEN,
            :NRMATRVEN,
            :VALBASVG,
            :VALBASAP,
            :VLCOMISVG,
            :VLCOMISAP,
            :DTQITBCO,
            :PCCOMIND,
            :PCCOMGER,
            :PCCOMSUP,
            :DTMOVABE,
            'VA0152B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP) VALUES ({FieldThreatment(this.CODPRODU)}, {FieldThreatment(this.NRCERTIF)}, 0, 0, '0' , 1103, {FieldThreatment(this.FONTE)}, {FieldThreatment(this.AGENCIA)}, {FieldThreatment(this.CODCLIEN)}, {FieldThreatment(this.NRMATRVEN)}, {FieldThreatment(this.VALBASVG)}, {FieldThreatment(this.VALBASAP)}, {FieldThreatment(this.VLCOMISVG)}, {FieldThreatment(this.VLCOMISAP)}, {FieldThreatment(this.DTQITBCO)}, {FieldThreatment(this.PCCOMIND)}, {FieldThreatment(this.PCCOMGER)}, {FieldThreatment(this.PCCOMSUP)}, {FieldThreatment(this.DTMOVABE)}, 'VA0152B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string CODPRODU { get; set; }
        public string NRCERTIF { get; set; }
        public string FONTE { get; set; }
        public string AGENCIA { get; set; }
        public string CODCLIEN { get; set; }
        public string NRMATRVEN { get; set; }
        public string VALBASVG { get; set; }
        public string VALBASAP { get; set; }
        public string VLCOMISVG { get; set; }
        public string VLCOMISAP { get; set; }
        public string DTQITBCO { get; set; }
        public string PCCOMIND { get; set; }
        public string PCCOMGER { get; set; }
        public string PCCOMSUP { get; set; }
        public string DTMOVABE { get; set; }

        public static void Execute(M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1 m_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1)
        {
            var ths = m_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1500_ESTORNA_FUNDO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}