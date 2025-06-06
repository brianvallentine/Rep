using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUBSTR(VALUE(DES_ABREV_MSG_CRITICA, ' ' ),1,60)
            INTO :ERROSVID-DESCR-ERRO
            FROM SEGUROS.VG_DM_MSG_CRITICA
            WHERE COD_MSG_CRITICA = :ERROSVID-COD-ERRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUBSTR(VALUE(DES_ABREV_MSG_CRITICA
							, ' ' )
							,1
							,60)
											FROM SEGUROS.VG_DM_MSG_CRITICA
											WHERE COD_MSG_CRITICA = '{this.ERROSVID_COD_ERRO}'
											WITH UR";

            return query;
        }
        public string ERROSVID_DESCR_ERRO { get; set; }
        public string ERROSVID_COD_ERRO { get; set; }

        public static R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1 Execute(R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1 r2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SELECT_ERROSVID_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERROSVID_DESCR_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}