using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9110B
{
    public class R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1 : QueryBasis<R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_AR_VERA_CRUZ
            (NOM_ARQUIVO,
            SEQ_GERACAO,
            TIPO_REGISTRO,
            SEQ_REGISTRO,
            STA_PROCESSAMENTO,
            COD_ERRO)
            VALUES (:GEARDETA-NOM-ARQUIVO,
            :GEARDETA-SEQ-GERACAO,
            :SIARVRCZ-TIPO-REGISTRO,
            :SIARVRCZ-SEQ-REGISTRO,
            :SIARVRCZ-STA-PROCESSAMENTO,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_AR_VERA_CRUZ (NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, STA_PROCESSAMENTO, COD_ERRO) VALUES ({FieldThreatment(this.GEARDETA_NOM_ARQUIVO)}, {FieldThreatment(this.GEARDETA_SEQ_GERACAO)}, {FieldThreatment(this.SIARVRCZ_TIPO_REGISTRO)}, {FieldThreatment(this.SIARVRCZ_SEQ_REGISTRO)}, {FieldThreatment(this.SIARVRCZ_STA_PROCESSAMENTO)}, NULL)";

            return query;
        }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string SIARVRCZ_TIPO_REGISTRO { get; set; }
        public string SIARVRCZ_SEQ_REGISTRO { get; set; }
        public string SIARVRCZ_STA_PROCESSAMENTO { get; set; }

        public static void Execute(R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1 r0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1)
        {
            var ths = r0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}