using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.EF0101S
{
    public class D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 : QueryBasis<D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_CONTRATO,
            PRZ_VIGENCIA
            INTO :LS-V0CONT-DATA-CONTRATO,
            :LS-V0CONT-PRZ-VIGENCIA
            FROM SEGUROS.V0CONTRATO_HABIT
            WHERE COD_PRODUTO = 6802
            AND COD_CLIENTE = 528094
            AND OPERACAO = 0
            AND PONTO_VENDA = 0
            AND NUM_CONTRATO = :LS-V0HAB01-NUM-CONTRATO
            AND DATA_SIT_INI <= :LS-SINI-DATORR
            AND VALUE(DATA_SIT_FIM,DATE( '9999-12-31' ))
            >= :LS-SINI-DATORR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_CONTRATO
							,
											PRZ_VIGENCIA
											FROM SEGUROS.V0CONTRATO_HABIT
											WHERE COD_PRODUTO = 6802
											AND COD_CLIENTE = 528094
											AND OPERACAO = 0
											AND PONTO_VENDA = 0
											AND NUM_CONTRATO = '{this.LS_V0HAB01_NUM_CONTRATO}'
											AND DATA_SIT_INI <= '{this.LS_SINI_DATORR}'
											AND VALUE(DATA_SIT_FIM
							,DATE( '9999-12-31' ))
											>= '{this.LS_SINI_DATORR}'";

            return query;
        }
        public string LS_V0CONT_DATA_CONTRATO { get; set; }
        public string LS_V0CONT_PRZ_VIGENCIA { get; set; }
        public string LS_V0HAB01_NUM_CONTRATO { get; set; }
        public string LS_SINI_DATORR { get; set; }

        public static D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 Execute(D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1)
        {
            var ths = d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1();
            var i = 0;
            dta.LS_V0CONT_DATA_CONTRATO = result[i++].Value?.ToString();
            dta.LS_V0CONT_PRZ_VIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}