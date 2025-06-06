using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1 : QueryBasis<M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FUNCIOCEF
				SET
				COD_SUREG =  '{this.SQL_SUREG}',
				COD_UNIDADE =  '{this.SQL_UNIDADE}',
				DIG_UNIDADE =  '{this.SQL_DV}',
				NOME_UNIDADE =  '{this.SQLCEF_NOME_UNID}',
				TIPO_VINCULO = 'EMPREGADO CEF' ,
				NOME_FUNCIONARIO =  '{this.SQL_NOME_FUNC}',
				NASCIMENTO =  '{this.SQL_DATA_NASC}',
				NUM_CPF =  '{this.SQL_CPF}',
				ENDERECO_CEF =  '{this.SQL_ENDERECO}',
				CIDADE_CEF =  '{this.SQL_CIDADE}',
				SIGLA_UF =  '{this.SQL_UF}',
				CEP =  '{this.SQL_CEP}',
				COD_AGENCIA =  '{this.SQL_AGENCIA}',
				OPERACAO_CONTA =  '{this.SQL_OPERACAO}',
				NUM_CONTA =  '{this.SQL_CONTA}',
				DIG_CONTA =  '{this.SQL_DV_CONTA}'
				WHERE  NUM_MATRICULA =  '{this.SQL_MATRICULA}'";

            return query;
        }
        public string SQLCEF_NOME_UNID { get; set; }
        public string SQL_NOME_FUNC { get; set; }
        public string SQL_DATA_NASC { get; set; }
        public string SQL_ENDERECO { get; set; }
        public string SQL_OPERACAO { get; set; }
        public string SQL_DV_CONTA { get; set; }
        public string SQL_UNIDADE { get; set; }
        public string SQL_AGENCIA { get; set; }
        public string SQL_CIDADE { get; set; }
        public string SQL_SUREG { get; set; }
        public string SQL_CONTA { get; set; }
        public string SQL_CPF { get; set; }
        public string SQL_CEP { get; set; }
        public string SQL_DV { get; set; }
        public string SQL_UF { get; set; }
        public string SQL_MATRICULA { get; set; }

        public static void Execute(M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1 m_1220_UPDATE_FUNC_DB_UPDATE_1_Update1)
        {
            var ths = m_1220_UPDATE_FUNC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1220_UPDATE_FUNC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}