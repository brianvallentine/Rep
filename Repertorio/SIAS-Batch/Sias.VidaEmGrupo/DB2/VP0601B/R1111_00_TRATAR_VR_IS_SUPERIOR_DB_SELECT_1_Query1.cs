using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1 : QueryBasis<R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT (*)
            INTO :WS-CADASTRO-IS-SUPERIOR
            FROM SEGUROS.GE_IS_SUPERIOR T1
            WHERE
            NUM_APOLICE = :GE400-NUM-APOLICE
            AND COD_PRODUTO = :GE400-COD-PRODUTO
            AND NUM_CPF = :GE400-NUM-CPF
            AND STA_IS_SUPERIOR = 'A'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT (*)
											FROM SEGUROS.GE_IS_SUPERIOR T1
											WHERE
											NUM_APOLICE = '{this.GE400_NUM_APOLICE}'
											AND COD_PRODUTO = '{this.GE400_COD_PRODUTO}'
											AND NUM_CPF = '{this.GE400_NUM_CPF}'
											AND STA_IS_SUPERIOR = 'A'
											WITH UR";

            return query;
        }
        public string WS_CADASTRO_IS_SUPERIOR { get; set; }
        public string GE400_NUM_APOLICE { get; set; }
        public string GE400_COD_PRODUTO { get; set; }
        public string GE400_NUM_CPF { get; set; }

        public static R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1 Execute(R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1 r1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1)
        {
            var ths = r1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CADASTRO_IS_SUPERIOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}