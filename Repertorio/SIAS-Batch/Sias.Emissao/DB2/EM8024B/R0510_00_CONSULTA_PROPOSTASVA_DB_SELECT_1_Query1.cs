using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1 : QueryBasis<R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_PRODUTO
            , A.SIT_REGISTRO
            INTO :PROPOVA-COD-PRODUTO
            , :PROPOVA-SIT-REGISTRO
            FROM SEGUROS.PROPOSTAS_VA A
            WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.COD_PRODUTO
											, A.SIT_REGISTRO
											FROM SEGUROS.PROPOSTAS_VA A
											WHERE A.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1 Execute(R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1 r0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1)
        {
            var ths = r0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0510_00_CONSULTA_PROPOSTASVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}