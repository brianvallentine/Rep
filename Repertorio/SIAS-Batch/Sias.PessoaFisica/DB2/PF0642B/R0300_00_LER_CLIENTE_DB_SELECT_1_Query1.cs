using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
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
            DATA_NASCIMENTO ,
            COD_PORTE_EMP ,
            COD_NATUREZA_ATIV ,
            COD_RAMO_ATIVIDADE ,
            COD_ATIVIDADE
            INTO
            :CLIENTES-COD-CLIENTE ,
            :CLIENTES-NOME-RAZAO ,
            :CLIENTES-TIPO-PESSOA ,
            :CLIENTES-CGCCPF ,
            :CLIENTES-SIT-REGISTRO ,
            :CLIENTES-DATA-NASCIMENTO:VIND-DTNASCI ,
            :CLIENTES-COD-PORTE-EMP:VIND-CODPORTEMP ,
            :CLIENTES-COD-NATUREZA-ATIV:VIND-NATATIV ,
            :CLIENTES-COD-RAMO-ATIVIDADE:VIND-RAMATIV,
            :CLIENTES-COD-ATIVIDADE:VIND-CODATIV
            FROM SEGUROS.CLIENTES
            WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE
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
							,
											COD_PORTE_EMP 
							,
											COD_NATUREZA_ATIV 
							,
											COD_RAMO_ATIVIDADE 
							,
											COD_ATIVIDADE
											FROM SEGUROS.CLIENTES
											WHERE COD_CLIENTE = '{this.CLIENTES_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_SIT_REGISTRO { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string VIND_DTNASCI { get; set; }
        public string CLIENTES_COD_PORTE_EMP { get; set; }
        public string VIND_CODPORTEMP { get; set; }
        public string CLIENTES_COD_NATUREZA_ATIV { get; set; }
        public string VIND_NATATIV { get; set; }
        public string CLIENTES_COD_RAMO_ATIVIDADE { get; set; }
        public string VIND_RAMATIV { get; set; }
        public string CLIENTES_COD_ATIVIDADE { get; set; }
        public string VIND_CODATIV { get; set; }

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
            dta.CLIENTES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.CLIENTES_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DTNASCI = string.IsNullOrWhiteSpace(dta.CLIENTES_DATA_NASCIMENTO) ? "-1" : "0";
            dta.CLIENTES_COD_PORTE_EMP = result[i++].Value?.ToString();
            dta.VIND_CODPORTEMP = string.IsNullOrWhiteSpace(dta.CLIENTES_COD_PORTE_EMP) ? "-1" : "0";
            dta.CLIENTES_COD_NATUREZA_ATIV = result[i++].Value?.ToString();
            dta.VIND_NATATIV = string.IsNullOrWhiteSpace(dta.CLIENTES_COD_NATUREZA_ATIV) ? "-1" : "0";
            dta.CLIENTES_COD_RAMO_ATIVIDADE = result[i++].Value?.ToString();
            dta.VIND_RAMATIV = string.IsNullOrWhiteSpace(dta.CLIENTES_COD_RAMO_ATIVIDADE) ? "-1" : "0";
            dta.CLIENTES_COD_ATIVIDADE = result[i++].Value?.ToString();
            dta.VIND_CODATIV = string.IsNullOrWhiteSpace(dta.CLIENTES_COD_ATIVIDADE) ? "-1" : "0";
            return dta;
        }

    }
}