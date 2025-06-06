using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R2810_00_MAX_SISINACO_DB_SELECT_1_Query1 : QueryBasis<R2810_00_MAX_SISINACO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_OCORR_SINIACO), 0)
            INTO :SISINACO-NUM-OCORR-SINIACO
            FROM SEGUROS.SI_SINISTRO_ACOMP
            WHERE COD_FONTE = :SISINACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_OCORR_SINIACO)
							, 0)
											FROM SEGUROS.SI_SINISTRO_ACOMP
											WHERE COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'
											WITH UR";

            return query;
        }
        public string SISINACO_NUM_OCORR_SINIACO { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

        public static R2810_00_MAX_SISINACO_DB_SELECT_1_Query1 Execute(R2810_00_MAX_SISINACO_DB_SELECT_1_Query1 r2810_00_MAX_SISINACO_DB_SELECT_1_Query1)
        {
            var ths = r2810_00_MAX_SISINACO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2810_00_MAX_SISINACO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2810_00_MAX_SISINACO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISINACO_NUM_OCORR_SINIACO = result[i++].Value?.ToString();
            return dta;
        }

    }
}