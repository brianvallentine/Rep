using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0705B
{
    public class R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1 : QueryBasis<R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IFNULL(COD_ERRO_SIVPF, 0)
            INTO :ERROVDAZ-COD-ERRO-SIVPF
            FROM SEGUROS.VG_DM_MSG_CRITICA
            WHERE COD_MSG_CRITICA = :ERROVDAZ-COD-ERRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IFNULL(COD_ERRO_SIVPF
							, 0)
											FROM SEGUROS.VG_DM_MSG_CRITICA
											WHERE COD_MSG_CRITICA = '{this.ERROVDAZ_COD_ERRO}'
											WITH UR";

            return query;
        }
        public string ERROVDAZ_COD_ERRO_SIVPF { get; set; }
        public string ERROVDAZ_COD_ERRO { get; set; }

        public static R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1 Execute(R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1 r0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERROVDAZ_COD_ERRO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}