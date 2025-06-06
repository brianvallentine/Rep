using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0505B
{
    public class M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1 : QueryBasis<M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1>
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
            TIMESTAMP,
            NUM_APOLICE,
            COD_SUBGRUPO,
            NUM_ENDOSSO,
            NUM_TITULO,
            NUM_PARCELA)
            VALUES (:COD-PRODUTO,
            0,
            0,
            :NRTERMO,
            '0' ,
            :CODOPER,
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
            'VE0505B' ,
            CURRENT TIMESTAMP,
            :NUM-APOLICE,
            :CODSUBES,
            0,
            0,
            :V0COMI-NRPARCEL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP, NUM_APOLICE, COD_SUBGRUPO, NUM_ENDOSSO, NUM_TITULO, NUM_PARCELA) VALUES ({FieldThreatment(this.COD_PRODUTO)}, 0, 0, {FieldThreatment(this.NRTERMO)}, '0' , {FieldThreatment(this.CODOPER)}, {FieldThreatment(this.FONTE)}, {FieldThreatment(this.AGENCIA)}, {FieldThreatment(this.CODCLIEN)}, {FieldThreatment(this.NRMATRVEN)}, {FieldThreatment(this.VALBASVG)}, {FieldThreatment(this.VALBASAP)}, {FieldThreatment(this.VLCOMISVG)}, {FieldThreatment(this.VLCOMISAP)}, {FieldThreatment(this.DTQITBCO)}, {FieldThreatment(this.PCCOMIND)}, {FieldThreatment(this.PCCOMGER)}, {FieldThreatment(this.PCCOMSUP)}, {FieldThreatment(this.DTMOVABE)}, 'VE0505B' , CURRENT TIMESTAMP, {FieldThreatment(this.NUM_APOLICE)}, {FieldThreatment(this.CODSUBES)}, 0, 0, {FieldThreatment(this.V0COMI_NRPARCEL)})";

            return query;
        }
        public string COD_PRODUTO { get; set; }
        public string NRTERMO { get; set; }
        public string CODOPER { get; set; }
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
        public string NUM_APOLICE { get; set; }
        public string CODSUBES { get; set; }
        public string V0COMI_NRPARCEL { get; set; }

        public static void Execute(M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1 m_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1)
        {
            var ths = m_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0300_GRAVA_FUNDO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}