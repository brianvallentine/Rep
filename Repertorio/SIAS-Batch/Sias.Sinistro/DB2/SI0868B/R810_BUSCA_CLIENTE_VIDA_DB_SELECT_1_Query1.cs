using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0868B
{
    public class R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1 : QueryBasis<R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CL.NOME_RAZAO
            INTO :CLIENTES-NOME-RAZAO
            FROM SEGUROS.SINISTRO_MESTRE SM,
            SEGUROS.SEGURADOS_VGAP S,
            SEGUROS.CLIENTES CL
            WHERE S.NUM_APOLICE = :SINISMES-NUM-APOLICE
            AND S.COD_SUBGRUPO = :SINISMES-COD-SUBGRUPO
            AND S.NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO
            AND CL.COD_CLIENTE = :SEGURVGA-COD-CLIENTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CL.NOME_RAZAO
											FROM SEGUROS.SINISTRO_MESTRE SM
							,
											SEGUROS.SEGURADOS_VGAP S
							,
											SEGUROS.CLIENTES CL
											WHERE S.NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											AND S.COD_SUBGRUPO = '{this.SINISMES_COD_SUBGRUPO}'
											AND S.NUM_CERTIFICADO = '{this.SINISMES_NUM_CERTIFICADO}'
											AND CL.COD_CLIENTE = '{this.SEGURVGA_COD_CLIENTE}'";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string SINISMES_NUM_CERTIFICADO { get; set; }
        public string SINISMES_COD_SUBGRUPO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SEGURVGA_COD_CLIENTE { get; set; }

        public static R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1 Execute(R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1 r810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1)
        {
            var ths = r810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}