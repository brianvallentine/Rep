using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1 : QueryBasis<A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(PCT_DESC_FIDEL +
            PCT_DESC_AGRUP +
            PCT_DESC_FUNC_PUBL +
            PCT_DESC_EXPER),0)
            INTO :PCT-DESCONTO-TOTAL
            FROM SEGUROS.MR_APOLICE_ITEM
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDO-NRENDOS
            AND NUM_ITEM = :ENDO-QTITENS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(PCT_DESC_FIDEL +
											PCT_DESC_AGRUP +
											PCT_DESC_FUNC_PUBL +
											PCT_DESC_EXPER)
							,0)
											FROM SEGUROS.MR_APOLICE_ITEM
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDO_NRENDOS}'
											AND NUM_ITEM = '{this.ENDO_QTITENS}'
											WITH UR";

            return query;
        }
        public string PCT_DESCONTO_TOTAL { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }
        public string ENDO_QTITENS { get; set; }

        public static A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1 Execute(A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1 a4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1)
        {
            var ths = a4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.PCT_DESCONTO_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}