using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1 : QueryBasis<R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINISTRO_CONTROLE
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_APOLICE,
            COD_SUBGRUPO,
            OCORR_HISTORICO,
            PEND_VISTORIA,
            PEND_RESSEGURO,
            SIT_REGISTRO,
            PEND_VIST_COMPL,
            COD_EMPRESA,
            TIMESTAMP,
            NUM_CERTIFICADO)
            VALUES (:ENDOSSOS-COD-FONTE,
            :SINISCON-NUM-PROTOCOLO-SINI,
            :SINISCON-DAC-PROTOCOLO-SINI,
            :SIARDEVC-NUM-APOLICE,
            0,
            1,
            'N' ,
            'N' ,
            '0' ,
            'N' ,
            0,
            CURRENT TIMESTAMP,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINISTRO_CONTROLE (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_APOLICE, COD_SUBGRUPO, OCORR_HISTORICO, PEND_VISTORIA, PEND_RESSEGURO, SIT_REGISTRO, PEND_VIST_COMPL, COD_EMPRESA, TIMESTAMP, NUM_CERTIFICADO) VALUES ({FieldThreatment(this.ENDOSSOS_COD_FONTE)}, {FieldThreatment(this.SINISCON_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SINISCON_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SIARDEVC_NUM_APOLICE)}, 0, 1, 'N' , 'N' , '0' , 'N' , 0, CURRENT TIMESTAMP, 0)";

            return query;
        }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string SINISCON_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISCON_DAC_PROTOCOLO_SINI { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }

        public static void Execute(R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1 r2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1)
        {
            var ths = r2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_INCLUI_SINISCON_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}