using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9215B
{
    public class R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1 : QueryBasis<R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_AR_RETORNO_VC
            (NOM_ARQUIVO_VC,
            SEQ_GERACAO_VC,
            TIPO_REGISTRO_VC,
            SEQ_REGISTRO_VC,
            NOM_ARQUIVO,
            SEQ_GERACAO,
            TIPO_REGISTRO,
            NUM_SEQ_REG)
            VALUES (:GEARDETA-NOM-ARQUIVO,
            :GEARDETA-SEQ-GERACAO,
            :SIARREVC-TIPO-REGISTRO-VC,
            :SIARREVC-SEQ-REGISTRO-VC,
            :SIARDEVC-NOM-ARQUIVO,
            :SIARDEVC-SEQ-GERACAO,
            :SIARDEVC-TIPO-REGISTRO,
            :SIARDEVC-SEQ-REGISTRO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_AR_RETORNO_VC (NOM_ARQUIVO_VC, SEQ_GERACAO_VC, TIPO_REGISTRO_VC, SEQ_REGISTRO_VC, NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, NUM_SEQ_REG) VALUES ({FieldThreatment(this.GEARDETA_NOM_ARQUIVO)}, {FieldThreatment(this.GEARDETA_SEQ_GERACAO)}, {FieldThreatment(this.SIARREVC_TIPO_REGISTRO_VC)}, {FieldThreatment(this.SIARREVC_SEQ_REGISTRO_VC)}, {FieldThreatment(this.SIARDEVC_NOM_ARQUIVO)}, {FieldThreatment(this.SIARDEVC_SEQ_GERACAO)}, {FieldThreatment(this.SIARDEVC_TIPO_REGISTRO)}, {FieldThreatment(this.SIARDEVC_SEQ_REGISTRO)})";

            return query;
        }
        public string GEARDETA_NOM_ARQUIVO { get; set; }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string SIARREVC_TIPO_REGISTRO_VC { get; set; }
        public string SIARREVC_SEQ_REGISTRO_VC { get; set; }
        public string SIARDEVC_NOM_ARQUIVO { get; set; }
        public string SIARDEVC_SEQ_GERACAO { get; set; }
        public string SIARDEVC_TIPO_REGISTRO { get; set; }
        public string SIARDEVC_SEQ_REGISTRO { get; set; }

        public static void Execute(R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1 r1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1)
        {
            var ths = r1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}