using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0300_00_LER_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R0300_00_LER_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_CLIENTE ,
            NOME_RAZAO ,
            TIPO_PESSOA ,
            CGCCPF ,
            SIT_REGISTRO ,
            DATA_NASCIMENTO
            INTO
            :DCLCLIENTES.COD-CLIENTE ,
            :DCLCLIENTES.NOME-RAZAO ,
            :DCLCLIENTES.TIPO-PESSOA ,
            :DCLCLIENTES.CGCCPF ,
            :DCLCLIENTES.SIT-REGISTRO ,
            :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_CLIENTE 
							,
											NOME_RAZAO 
							,
											TIPO_PESSOA 
							,
											CGCCPF 
							,
											SIT_REGISTRO 
							,
											DATA_NASCIMENTO
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string COD_CLIENTE { get; set; }
        public string NOME_RAZAO { get; set; }
        public string TIPO_PESSOA { get; set; }
        public string CGCCPF { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASCI { get; set; }

        public static R0300_00_LER_CLIENTE_DB_SELECT_1_Query1 Execute(R0300_00_LER_CLIENTE_DB_SELECT_1_Query1 r0300_00_LER_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_LER_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_LER_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_LER_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_CLIENTE = result[i++].Value?.ToString();
            dta.NOME_RAZAO = result[i++].Value?.ToString();
            dta.TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CGCCPF = result[i++].Value?.ToString();
            dta.SIT_REGISTRO = result[i++].Value?.ToString();
            dta.DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASCI = string.IsNullOrWhiteSpace(dta.DATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}