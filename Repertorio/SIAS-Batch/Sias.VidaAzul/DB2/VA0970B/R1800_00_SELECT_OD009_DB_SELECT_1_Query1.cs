using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R1800_00_SELECT_OD009_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_OD009_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_BANCO ,
            COD_AGENCIA ,
            NUM_OPERACAO_CONTA ,
            NUM_CONTA
            INTO :OD009-COD-BANCO ,
            :OD009-COD-AGENCIA ,
            :OD009-NUM-OPERACAO-CONTA,
            :OD009-NUM-CONTA
            FROM ODS.OD_PESS_CONTA_BANC
            WHERE NUM_PESSOA = :GE368-NUM-PESSOA
            AND SEQ_CONTA_BANCARIA = :GE368-SEQ-ENTIDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_BANCO 
							,
											COD_AGENCIA 
							,
											NUM_OPERACAO_CONTA 
							,
											NUM_CONTA
											FROM ODS.OD_PESS_CONTA_BANC
											WHERE NUM_PESSOA = '{this.GE368_NUM_PESSOA}'
											AND SEQ_CONTA_BANCARIA = '{this.GE368_SEQ_ENTIDADE}'";

            return query;
        }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string GE368_SEQ_ENTIDADE { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R1800_00_SELECT_OD009_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_OD009_DB_SELECT_1_Query1 r1800_00_SELECT_OD009_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_OD009_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_OD009_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_OD009_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD009_COD_BANCO = result[i++].Value?.ToString();
            dta.OD009_COD_AGENCIA = result[i++].Value?.ToString();
            dta.OD009_NUM_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.OD009_NUM_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}