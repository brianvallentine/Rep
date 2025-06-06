using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0726B
{
    public class R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 : QueryBasis<R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES
            (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO,
            :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM,
            :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF,
            :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO,
            :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER,
            :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES ({FieldThreatment(this.ARQSIVPF_SIGLA_ARQUIVO)}, {FieldThreatment(this.ARQSIVPF_SISTEMA_ORIGEM)}, {FieldThreatment(this.ARQSIVPF_NSAS_SIVPF)}, {FieldThreatment(this.ARQSIVPF_DATA_GERACAO)}, {FieldThreatment(this.ARQSIVPF_QTDE_REG_GER)}, {FieldThreatment(this.ARQSIVPF_DATA_PROCESSAMENTO)})";

            return query;
        }
        public string ARQSIVPF_SIGLA_ARQUIVO { get; set; }
        public string ARQSIVPF_SISTEMA_ORIGEM { get; set; }
        public string ARQSIVPF_NSAS_SIVPF { get; set; }
        public string ARQSIVPF_DATA_GERACAO { get; set; }
        public string ARQSIVPF_QTDE_REG_GER { get; set; }
        public string ARQSIVPF_DATA_PROCESSAMENTO { get; set; }

        public static void Execute(R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1)
        {
            var ths = r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}