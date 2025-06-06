using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1 : QueryBasis<DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MIN(NUM_FATURA),0)
            INTO :FATURAS-NUM-FATURA
            FROM SEGUROS.FATURAS
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO
            AND COD_OPERACAO IN (200, 300)
            AND NUM_ENDOSSO > 0
            AND NUM_RCAP = :RCAPS-NUM-RCAP
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MIN(NUM_FATURA)
							,0)
											FROM SEGUROS.FATURAS
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.VGSOLFAT_COD_SUBGRUPO}'
											AND COD_OPERACAO IN (200
							, 300)
											AND NUM_ENDOSSO > 0
											AND NUM_RCAP = '{this.RCAPS_NUM_RCAP}'
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string FATURAS_NUM_FATURA { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }

        public static DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1 Execute(DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1 dB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1)
        {
            var ths = dB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB141_ACESSA_FATURAS_MIN_DB_SELECT_1_Query1();
            var i = 0;
            dta.FATURAS_NUM_FATURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}