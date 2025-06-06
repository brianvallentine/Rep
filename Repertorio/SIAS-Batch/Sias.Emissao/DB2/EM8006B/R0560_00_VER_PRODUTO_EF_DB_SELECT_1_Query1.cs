using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1 : QueryBasis<R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT (*)
            INTO :WS-COUNT
            FROM SEGUROS.EF_ENVIO_MOVTO_SAP
            WHERE NUM_OCORR_MOVTO = :EF150-NUM-OCORR-MOVTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT (*)
											FROM SEGUROS.EF_ENVIO_MOVTO_SAP
											WHERE NUM_OCORR_MOVTO = '{this.EF150_NUM_OCORR_MOVTO}'
											WITH UR";

            return query;
        }
        public string WS_COUNT { get; set; }
        public string EF150_NUM_OCORR_MOVTO { get; set; }

        public static R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1 Execute(R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1 r0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1)
        {
            var ths = r0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}