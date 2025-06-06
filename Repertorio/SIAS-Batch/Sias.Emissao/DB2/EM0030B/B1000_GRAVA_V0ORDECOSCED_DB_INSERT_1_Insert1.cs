using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1 : QueryBasis<B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0ORDECOSCED
            VALUES (:NORD-NUM-APOLICE, :NORD-NRENDOS,
            :NORD-CODCOSS , :WORD-NRORDEM,
            :NORD-COD-EMPRESA:NORD-EMPRESA-I,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0ORDECOSCED VALUES ({FieldThreatment(this.NORD_NUM_APOLICE)}, {FieldThreatment(this.NORD_NRENDOS)}, {FieldThreatment(this.NORD_CODCOSS)} , {FieldThreatment(this.WORD_NRORDEM)},  {FieldThreatment((this.NORD_EMPRESA_I?.ToInt() == -1 ? null : this.NORD_COD_EMPRESA))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string NORD_NUM_APOLICE { get; set; }
        public string NORD_NRENDOS { get; set; }
        public string NORD_CODCOSS { get; set; }
        public string WORD_NRORDEM { get; set; }
        public string NORD_COD_EMPRESA { get; set; }
        public string NORD_EMPRESA_I { get; set; }

        public static void Execute(B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1 b1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1)
        {
            var ths = b1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}