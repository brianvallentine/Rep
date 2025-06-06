using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
{
    public class R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-QTDSEG
            FROM SEGUROS.SEGURADOS_VGAP
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            AND SIT_REGISTRO IN ( '0' , '1' )
            AND COD_PROFISSAO = 9999
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.SEGURADOS_VGAP
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											AND SIT_REGISTRO IN ( '0' 
							, '1' )
											AND COD_PROFISSAO = 9999";

            return query;
        }
        public string WHOST_QTDSEG { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 r2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_SEGURVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDSEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}