using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0036_INSERT_DB_INSERT_1_Insert1 : QueryBasis<M_0036_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTABILVA
            (NRCERTIF,
            NRPARCEL,
            NRTIT,
            OCOORHIST,
            NUM_APOLICE,
            CODSUBES,
            FONTE,
            NRENDOS,
            PRMVG,
            PRMAP,
            DTMOVTO,
            SITUACAO,
            CODOPER,
            TIMESTAMP,
            DTFATUR)
            VALUES
            (:HCTA-NRCERTIF,
            :HCTA-NRPARCEL,
            :HCVA-NRTIT,
            :HCVA-OCORHIST,
            :PROP-NUM-APOLICE,
            :PROP-CODSUBES,
            :PROP-FONTE,
            0,
            :HOST-PRMVG,
            :HOST-PRMAP,
            :DTMOVABE,
            '0' ,
            501,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTABILVA (NRCERTIF, NRPARCEL, NRTIT, OCOORHIST, NUM_APOLICE, CODSUBES, FONTE, NRENDOS, PRMVG, PRMAP, DTMOVTO, SITUACAO, CODOPER, TIMESTAMP, DTFATUR) VALUES ({FieldThreatment(this.HCTA_NRCERTIF)}, {FieldThreatment(this.HCTA_NRPARCEL)}, {FieldThreatment(this.HCVA_NRTIT)}, {FieldThreatment(this.HCVA_OCORHIST)}, {FieldThreatment(this.PROP_NUM_APOLICE)}, {FieldThreatment(this.PROP_CODSUBES)}, {FieldThreatment(this.PROP_FONTE)}, 0, {FieldThreatment(this.HOST_PRMVG)}, {FieldThreatment(this.HOST_PRMAP)}, {FieldThreatment(this.DTMOVABE)}, '0' , 501, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string HCTA_NRCERTIF { get; set; }
        public string HCTA_NRPARCEL { get; set; }
        public string HCVA_NRTIT { get; set; }
        public string HCVA_OCORHIST { get; set; }
        public string PROP_NUM_APOLICE { get; set; }
        public string PROP_CODSUBES { get; set; }
        public string PROP_FONTE { get; set; }
        public string HOST_PRMVG { get; set; }
        public string HOST_PRMAP { get; set; }
        public string DTMOVABE { get; set; }

        public static void Execute(M_0036_INSERT_DB_INSERT_1_Insert1 m_0036_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = m_0036_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0036_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}