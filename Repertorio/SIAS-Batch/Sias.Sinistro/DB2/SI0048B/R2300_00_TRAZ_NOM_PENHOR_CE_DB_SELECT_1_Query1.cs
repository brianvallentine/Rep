using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1 : QueryBasis<R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.NOME_RAZAO,
            C.TIPO_PESSOA,
            C.CGCCPF,
            VALUE(C.DATA_NASCIMENTO,DATE( '0001-01-01' ))
            INTO :CLIENTES-NOME-RAZAO,
            :CLIENTES-TIPO-PESSOA,
            :CLIENTES-CGCCPF,
            :CLIENTES-DATA-NASCIMENTO
            FROM SEGUROS.SEGURADOS_VGAP A,
            SEGUROS.SINISTRO_MESTRE B,
            SEGUROS.CLIENTES C
            WHERE B.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND A.COD_CLIENTE = C.COD_CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT C.NOME_RAZAO
							,
											C.TIPO_PESSOA
							,
											C.CGCCPF
							,
											VALUE(C.DATA_NASCIMENTO
							,DATE( '0001-01-01' ))
											FROM SEGUROS.SEGURADOS_VGAP A
							,
											SEGUROS.SINISTRO_MESTRE B
							,
											SEGUROS.CLIENTES C
											WHERE B.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.COD_SUBGRUPO = A.COD_SUBGRUPO
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND A.COD_CLIENTE = C.COD_CLIENTE
											WITH UR";

            return query;
        }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1 Execute(R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1 r2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}