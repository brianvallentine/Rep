using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1 : QueryBasis<R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO,
            COD_CLIENTE
            INTO :V0SEGV-NRCERTIF,
            :V0SEGV-CODCLIEN
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_MATRICULA = :V0AVER-NRMATRIC
            AND NUM_APOLICE = 93010000890
            AND COD_SUBGRUPO = 1
            AND SIT_REGISTRO IN ( '0' , '1' )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
							,
											COD_CLIENTE
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_MATRICULA = '{this.V0AVER_NRMATRIC}'
											AND NUM_APOLICE = 93010000890
											AND COD_SUBGRUPO = 1
											AND SIT_REGISTRO IN ( '0' 
							, '1' )";

            return query;
        }
        public string V0SEGV_NRCERTIF { get; set; }
        public string V0SEGV_CODCLIEN { get; set; }
        public string V0AVER_NRMATRIC { get; set; }

        public static R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1 Execute(R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1 r6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1)
        {
            var ths = r6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6030_00_SELECT_COBERTURAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SEGV_NRCERTIF = result[i++].Value?.ToString();
            dta.V0SEGV_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}