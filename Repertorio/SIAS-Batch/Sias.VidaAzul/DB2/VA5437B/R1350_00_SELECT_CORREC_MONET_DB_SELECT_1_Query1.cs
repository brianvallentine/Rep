using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1 : QueryBasis<R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(DATA_OPERACAO),:OPCPAGVI-DATA-INIVIGENCIA)
            + :OPCPAGVI-PERI-PAGAMENTO MONTH
            INTO :WS-DATA-OPER-CORR-MONET
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND COD_OPERACAO IN (101, 895)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(DATA_OPERACAO)
							,'{this.OPCPAGVI_DATA_INIVIGENCIA}')
											+ {this.OPCPAGVI_PERI_PAGAMENTO} MONTH
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND COD_OPERACAO IN (101
							, 895)
											WITH UR";

            return query;
        }
        public string WS_DATA_OPER_CORR_MONET { get; set; }
        public string OPCPAGVI_DATA_INIVIGENCIA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }

        public static R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1 Execute(R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1 r1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1)
        {
            var ths = r1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_OPER_CORR_MONET = result[i++].Value?.ToString();
            return dta;
        }

    }
}