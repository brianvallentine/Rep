using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB094_INCLUI_PESSOA_DB_INSERT_1_Insert1 : QueryBasis<DB094_INCLUI_PESSOA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA
            (COD_PESSOA,
            NOME_PESSOA,
            TIMESTAMP,
            COD_USUARIO,
            TIPO_PESSOA,
            SIGLA_PESSOA)
            VALUES
            (:PESSOA-COD-PESSOA,
            :PESSOA-NOME-PESSOA,
            CURRENT TIMESTAMP,
            :PESSOA-COD-USUARIO,
            :PESSOA-TIPO-PESSOA,
            :PESSOA-SIGLA-PESSOA)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA (COD_PESSOA, NOME_PESSOA, TIMESTAMP, COD_USUARIO, TIPO_PESSOA, SIGLA_PESSOA) VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)}, {FieldThreatment(this.PESSOA_NOME_PESSOA)}, CURRENT TIMESTAMP, {FieldThreatment(this.PESSOA_COD_USUARIO)}, {FieldThreatment(this.PESSOA_TIPO_PESSOA)}, {FieldThreatment(this.PESSOA_SIGLA_PESSOA)})";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string PESSOA_NOME_PESSOA { get; set; }
        public string PESSOA_COD_USUARIO { get; set; }
        public string PESSOA_TIPO_PESSOA { get; set; }
        public string PESSOA_SIGLA_PESSOA { get; set; }

        public static void Execute(DB094_INCLUI_PESSOA_DB_INSERT_1_Insert1 dB094_INCLUI_PESSOA_DB_INSERT_1_Insert1)
        {
            var ths = dB094_INCLUI_PESSOA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB094_INCLUI_PESSOA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}