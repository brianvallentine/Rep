using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1 : QueryBasis<R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO,
            BAIRRO,
            CIDADE
            INTO :ENDERECO-ENDERECO,
            :ENDERECO-BAIRRO,
            :ENDERECO-CIDADE
            FROM SEGUROS.ENDERECOS
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
            AND COD_ENDERECO = :ENDERECO-COD-ENDERECO
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ENDERECO
							,
											BAIRRO
							,
											CIDADE
											FROM SEGUROS.ENDERECOS
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											AND COD_ENDERECO = '{this.ENDERECO_COD_ENDERECO}'
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string ENDERECO_ENDERECO { get; set; }
        public string ENDERECO_BAIRRO { get; set; }
        public string ENDERECO_CIDADE { get; set; }
        public string ENDERECO_COD_ENDERECO { get; set; }
        public string CLIENTES_COD_CLIENTE { get; set; }

        public static R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1 Execute(R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1 r1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_PROCESSA_COMPL_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.ENDERECO_CIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}