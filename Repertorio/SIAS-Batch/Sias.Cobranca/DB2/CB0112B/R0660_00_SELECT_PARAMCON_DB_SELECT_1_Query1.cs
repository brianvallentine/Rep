using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0112B
{
    public class R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1 : QueryBasis<R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NSAS
            INTO :PARAMCON-NSAS
            FROM SEGUROS.PARAM_CONTACEF
            WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC
            AND COD_PRODUTO = :PARAMCON-COD-PRODUTO
            AND COD_CONVENIO = :PARAMCON-COD-CONVENIO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NSAS
											FROM SEGUROS.PARAM_CONTACEF
											WHERE TIPO_MOVTO_CC = '{this.PARAMCON_TIPO_MOVTO_CC}'
											AND COD_PRODUTO = '{this.PARAMCON_COD_PRODUTO}'
											AND COD_CONVENIO = '{this.PARAMCON_COD_CONVENIO}'
											WITH UR";

            return query;
        }
        public string PARAMCON_NSAS { get; set; }
        public string PARAMCON_TIPO_MOVTO_CC { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_COD_PRODUTO { get; set; }

        public static R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1 Execute(R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1 r0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1)
        {
            var ths = r0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMCON_NSAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}