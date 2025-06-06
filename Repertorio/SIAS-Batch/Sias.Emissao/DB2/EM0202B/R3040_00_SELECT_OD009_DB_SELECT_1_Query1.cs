using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R3040_00_SELECT_OD009_DB_SELECT_1_Query1 : QueryBasis<R3040_00_SELECT_OD009_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(T1.COD_BANCO, 0),
            VALUE(T1.COD_AGENCIA, 0),
            VALUE(T1.NUM_OPERACAO_CONTA, 0),
            VALUE(T1.NUM_CONTA, 0) ,
            VALUE(T1.NUM_DV_CONTA, ' ' )
            INTO :OD009-COD-BANCO,
            :OD009-COD-AGENCIA,
            :OD009-NUM-OPERACAO-CONTA,
            :OD009-NUM-CONTA,
            :OD009-NUM-DV-CONTA
            FROM ODS.OD_PESS_CONTA_BANC T1
            WHERE T1.NUM_PESSOA = :GE368-NUM-PESSOA
            AND T1.STA_CONTA = 'A'
            AND T1.SEQ_CONTA_BANCARIA =
            (SELECT MAX(T2.SEQ_CONTA_BANCARIA)
            FROM ODS.OD_PESS_CONTA_BANC T2
            WHERE T2.NUM_PESSOA = T1.NUM_PESSOA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(T1.COD_BANCO
							, 0)
							,
											VALUE(T1.COD_AGENCIA
							, 0)
							,
											VALUE(T1.NUM_OPERACAO_CONTA
							, 0)
							,
											VALUE(T1.NUM_CONTA
							, 0) 
							,
											VALUE(T1.NUM_DV_CONTA
							, ' ' )
											FROM ODS.OD_PESS_CONTA_BANC T1
											WHERE T1.NUM_PESSOA = '{this.GE368_NUM_PESSOA}'
											AND T1.STA_CONTA = 'A'
											AND T1.SEQ_CONTA_BANCARIA =
											(SELECT MAX(T2.SEQ_CONTA_BANCARIA)
											FROM ODS.OD_PESS_CONTA_BANC T2
											WHERE T2.NUM_PESSOA = T1.NUM_PESSOA)";

            return query;
        }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string OD009_NUM_DV_CONTA { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R3040_00_SELECT_OD009_DB_SELECT_1_Query1 Execute(R3040_00_SELECT_OD009_DB_SELECT_1_Query1 r3040_00_SELECT_OD009_DB_SELECT_1_Query1)
        {
            var ths = r3040_00_SELECT_OD009_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3040_00_SELECT_OD009_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3040_00_SELECT_OD009_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD009_COD_BANCO = result[i++].Value?.ToString();
            dta.OD009_COD_AGENCIA = result[i++].Value?.ToString();
            dta.OD009_NUM_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_DV_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}