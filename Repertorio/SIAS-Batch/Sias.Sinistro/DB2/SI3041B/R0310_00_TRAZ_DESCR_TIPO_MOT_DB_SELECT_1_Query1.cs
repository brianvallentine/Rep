using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI3041B
{
    public class R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1 : QueryBasis<R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DES_TIPO_MOTIVO
            INTO :SITIPMOT-DES-TIPO-MOTIVO
            FROM SEGUROS.SI_TIPO_MOTIVO
            WHERE COD_TIPO_MOTIVO = :SIMOTIVO-COD-TIPO-MOTIVO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DES_TIPO_MOTIVO
											FROM SEGUROS.SI_TIPO_MOTIVO
											WHERE COD_TIPO_MOTIVO = '{this.SIMOTIVO_COD_TIPO_MOTIVO}'
											WITH UR";

            return query;
        }
        public string SITIPMOT_DES_TIPO_MOTIVO { get; set; }
        public string SIMOTIVO_COD_TIPO_MOTIVO { get; set; }

        public static R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1 Execute(R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1 r0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1)
        {
            var ths = r0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0310_00_TRAZ_DESCR_TIPO_MOT_DB_SELECT_1_Query1();
            var i = 0;
            dta.SITIPMOT_DES_TIPO_MOTIVO = result[i++].Value?.ToString();
            return dta;
        }

    }
}