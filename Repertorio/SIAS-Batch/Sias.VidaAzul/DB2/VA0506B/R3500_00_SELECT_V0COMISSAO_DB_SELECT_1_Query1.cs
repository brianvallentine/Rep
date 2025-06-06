using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0506B
{
    public class R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 : QueryBasis<R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_RECIBO
            INTO :COMISSOE-NUM-RECIBO
            FROM SEGUROS.COMISSOES
            WHERE NUM_APOLICE = :HISCONPA-NUM-APOLICE
            AND NUM_ENDOSSO = :HISCONPA-NUM-ENDOSSO
            AND NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_RECIBO
											FROM SEGUROS.COMISSOES
											WHERE NUM_APOLICE = '{this.HISCONPA_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.HISCONPA_NUM_ENDOSSO}'
											AND NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string COMISSOE_NUM_RECIBO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_APOLICE { get; set; }
        public string HISCONPA_NUM_ENDOSSO { get; set; }

        public static R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 Execute(R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 r3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1)
        {
            var ths = r3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3500_00_SELECT_V0COMISSAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.COMISSOE_NUM_RECIBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}