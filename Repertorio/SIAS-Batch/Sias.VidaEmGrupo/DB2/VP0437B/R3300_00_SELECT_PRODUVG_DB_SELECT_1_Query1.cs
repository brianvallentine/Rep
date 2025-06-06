using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ID_SISTEMA,
            VALUE(CODRELAT, '********' )
            INTO :PRODUVG-ID-SISTEMA,
            :PRODUVG-CODRELAT
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE
            AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ID_SISTEMA
							,
											VALUE(CODRELAT
							, '********' )
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.SEGURVGA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SEGURVGA_COD_SUBGRUPO}'";

            return query;
        }
        public string PRODUVG_ID_SISTEMA { get; set; }
        public string PRODUVG_CODRELAT { get; set; }
        public string SEGURVGA_COD_SUBGRUPO { get; set; }
        public string SEGURVGA_NUM_APOLICE { get; set; }

        public static R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1 Execute(R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1 r3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_SELECT_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_ID_SISTEMA = result[i++].Value?.ToString();
            dta.PRODUVG_CODRELAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}