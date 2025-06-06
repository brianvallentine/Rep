using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_GRUPO_SUSEP
            INTO :VG080-COD-GRUPO-SUSEP
            FROM SEGUROS.VG_PARAM_RAMO_CONJ
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE
            AND COD_SUBGRUPO = :V0ENDO-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_GRUPO_SUSEP
											FROM SEGUROS.VG_PARAM_RAMO_CONJ
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0ENDO_CODSUBES}'";

            return query;
        }
        public string VG080_COD_GRUPO_SUSEP { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_CODSUBES { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1();
            var i = 0;
            dta.VG080_COD_GRUPO_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}