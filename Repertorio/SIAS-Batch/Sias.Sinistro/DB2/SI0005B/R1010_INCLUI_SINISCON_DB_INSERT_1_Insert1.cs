using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1 : QueryBasis<R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_CONTROLE
            ( COD_FONTE
            ,NUM_PROTOCOLO_SINI
            ,DAC_PROTOCOLO_SINI
            ,NUM_APOLICE
            ,COD_SUBGRUPO
            ,OCORR_HISTORICO
            ,PEND_VISTORIA
            ,PEND_RESSEGURO
            ,SIT_REGISTRO
            ,PEND_VIST_COMPL
            ,COD_EMPRESA
            ,TIMESTAMP
            ,NUM_CERTIFICADO
            )
            VALUES
            (:SINISCON-COD-FONTE
            ,:SINISCON-NUM-PROTOCOLO-SINI
            ,:SINISCON-DAC-PROTOCOLO-SINI
            ,:SINISCON-NUM-APOLICE
            ,:SINISCON-COD-SUBGRUPO
            ,:SINISCON-OCORR-HISTORICO
            ,:SINISCON-PEND-VISTORIA
            ,:SINISCON-PEND-RESSEGURO
            ,:SINISCON-SIT-REGISTRO
            ,:SINISCON-PEND-VIST-COMPL
            ,:SINISCON-COD-EMPRESA
            , CURRENT TIMESTAMP
            ,:SINISCON-NUM-CERTIFICADO
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_CONTROLE ( COD_FONTE ,NUM_PROTOCOLO_SINI ,DAC_PROTOCOLO_SINI ,NUM_APOLICE ,COD_SUBGRUPO ,OCORR_HISTORICO ,PEND_VISTORIA ,PEND_RESSEGURO ,SIT_REGISTRO ,PEND_VIST_COMPL ,COD_EMPRESA ,TIMESTAMP ,NUM_CERTIFICADO ) VALUES ({FieldThreatment(this.SINISCON_COD_FONTE)} ,{FieldThreatment(this.SINISCON_NUM_PROTOCOLO_SINI)} ,{FieldThreatment(this.SINISCON_DAC_PROTOCOLO_SINI)} ,{FieldThreatment(this.SINISCON_NUM_APOLICE)} ,{FieldThreatment(this.SINISCON_COD_SUBGRUPO)} ,{FieldThreatment(this.SINISCON_OCORR_HISTORICO)} ,{FieldThreatment(this.SINISCON_PEND_VISTORIA)} ,{FieldThreatment(this.SINISCON_PEND_RESSEGURO)} ,{FieldThreatment(this.SINISCON_SIT_REGISTRO)} ,{FieldThreatment(this.SINISCON_PEND_VIST_COMPL)} ,{FieldThreatment(this.SINISCON_COD_EMPRESA)} , CURRENT TIMESTAMP ,{FieldThreatment(this.SINISCON_NUM_CERTIFICADO)} )";

            return query;
        }
        public string SINISCON_COD_FONTE { get; set; }
        public string SINISCON_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISCON_DAC_PROTOCOLO_SINI { get; set; }
        public string SINISCON_NUM_APOLICE { get; set; }
        public string SINISCON_COD_SUBGRUPO { get; set; }
        public string SINISCON_OCORR_HISTORICO { get; set; }
        public string SINISCON_PEND_VISTORIA { get; set; }
        public string SINISCON_PEND_RESSEGURO { get; set; }
        public string SINISCON_SIT_REGISTRO { get; set; }
        public string SINISCON_PEND_VIST_COMPL { get; set; }
        public string SINISCON_COD_EMPRESA { get; set; }
        public string SINISCON_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1 r1010_INCLUI_SINISCON_DB_INSERT_1_Insert1)
        {
            var ths = r1010_INCLUI_SINISCON_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1010_INCLUI_SINISCON_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}