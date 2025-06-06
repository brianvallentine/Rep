using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0501B
{
    public class INICIO_LOOP_NOME_DB_INSERT_1_Insert1 : QueryBasis<INICIO_LOOP_NOME_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO ODS.OD_PESSOA
            (NUM_PESSOA ,
            DTH_CADASTRAMENTO ,
            NUM_DV_PESSOA ,
            IND_PESSOA ,
            STA_INF_INTEGRA)
            VALUES (:OD001-NUM-PESSOA ,
            :OD001-DTH-CADASTRAMENTO ,
            :OD001-NUM-DV-PESSOA ,
            :OD001-IND-PESSOA ,
            :OD001-STA-INF-INTEGRA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO ODS.OD_PESSOA (NUM_PESSOA , DTH_CADASTRAMENTO , NUM_DV_PESSOA , IND_PESSOA , STA_INF_INTEGRA) VALUES ({FieldThreatment(this.OD001_NUM_PESSOA)} , {FieldThreatment(this.OD001_DTH_CADASTRAMENTO)} , {FieldThreatment(this.OD001_NUM_DV_PESSOA)} , {FieldThreatment(this.OD001_IND_PESSOA)} , {FieldThreatment(this.OD001_STA_INF_INTEGRA)})";

            return query;
        }
        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_DTH_CADASTRAMENTO { get; set; }
        public string OD001_NUM_DV_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string OD001_STA_INF_INTEGRA { get; set; }

        public static void Execute(INICIO_LOOP_NOME_DB_INSERT_1_Insert1 iNICIO_LOOP_NOME_DB_INSERT_1_Insert1)
        {
            var ths = iNICIO_LOOP_NOME_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override INICIO_LOOP_NOME_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}