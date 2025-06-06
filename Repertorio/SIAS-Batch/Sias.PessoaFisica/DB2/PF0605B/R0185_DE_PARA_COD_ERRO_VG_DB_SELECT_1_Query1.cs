using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1 : QueryBasis<R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MSG_CRITICA,
            COD_ERRO_SIVPF
            INTO :ERROVDAZ-COD-ERRO,
            :ERROVDAZ-COD-ERRO-SIVPF
            FROM SEGUROS.VG_DM_MSG_CRITICA
            WHERE COD_MSG_CRITICA = :ERROVDAZ-COD-ERRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MSG_CRITICA
							,
											COD_ERRO_SIVPF
											FROM SEGUROS.VG_DM_MSG_CRITICA
											WHERE COD_MSG_CRITICA = '{this.ERROVDAZ_COD_ERRO}'
											WITH UR";

            return query;
        }
        public string ERROVDAZ_COD_ERRO { get; set; }
        public string ERROVDAZ_COD_ERRO_SIVPF { get; set; }

        public static R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1 Execute(R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1 r0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1)
        {
            var ths = r0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERROVDAZ_COD_ERRO = result[i++].Value?.ToString();
            dta.ERROVDAZ_COD_ERRO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}