using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0717B
{
    public class R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 : QueryBasis<R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES
            (:PROPFIDH-NUM-IDENTIFICACAO ,
            :PROPFIDH-DATA-SITUACAO ,
            :PROPFIDH-NSAS-SIVPF ,
            :PROPFIDH-NSL ,
            :PROPFIDH-SIT-PROPOSTA ,
            :PROPFIDH-SIT-COBRANCA-SIVPF,
            :PROPFIDH-SIT-MOTIVO-SIVPF ,
            :PROPFIDH-COD-EMPRESA-SIVPF ,
            :PROPFIDH-COD-PRODUTO-SIVPF)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ({FieldThreatment(this.PROPFIDH_NUM_IDENTIFICACAO)} , {FieldThreatment(this.PROPFIDH_DATA_SITUACAO)} , {FieldThreatment(this.PROPFIDH_NSAS_SIVPF)} , {FieldThreatment(this.PROPFIDH_NSL)} , {FieldThreatment(this.PROPFIDH_SIT_PROPOSTA)} , {FieldThreatment(this.PROPFIDH_SIT_COBRANCA_SIVPF)}, {FieldThreatment(this.PROPFIDH_SIT_MOTIVO_SIVPF)} , {FieldThreatment(this.PROPFIDH_COD_EMPRESA_SIVPF)} , {FieldThreatment(this.PROPFIDH_COD_PRODUTO_SIVPF)})";

            return query;
        }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPFIDH_NSAS_SIVPF { get; set; }
        public string PROPFIDH_NSL { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }
        public string PROPFIDH_SIT_COBRANCA_SIVPF { get; set; }
        public string PROPFIDH_SIT_MOTIVO_SIVPF { get; set; }
        public string PROPFIDH_COD_EMPRESA_SIVPF { get; set; }
        public string PROPFIDH_COD_PRODUTO_SIVPF { get; set; }

        public static void Execute(R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1)
        {
            var ths = r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}