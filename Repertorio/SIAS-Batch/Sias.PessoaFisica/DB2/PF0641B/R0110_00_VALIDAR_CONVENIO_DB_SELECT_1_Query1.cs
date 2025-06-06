using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0641B
{
    public class R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 : QueryBasis<R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_ARQUIVO
            INTO :DCLCONVENIO-SIVPF.DESCR-ARQUIVO
            FROM SEGUROS.CONVENIO_SIVPF
            WHERE SIGLA_ARQUIVO = :DCLCONVENIO-SIVPF.SIGLA-ARQUIVO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_ARQUIVO
											FROM SEGUROS.CONVENIO_SIVPF
											WHERE SIGLA_ARQUIVO = '{this.SIGLA_ARQUIVO}'
											WITH UR";

            return query;
        }
        public string DESCR_ARQUIVO { get; set; }
        public string SIGLA_ARQUIVO { get; set; }

        public static R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 Execute(R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1)
        {
            var ths = r0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.DESCR_ARQUIVO = result[i++].Value?.ToString();
            return dta;
        }

    }
}