using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PTACOMOS
{
    public class R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 : QueryBasis<R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SI_PROTOCOLO_ACOMP
            (COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            OCORR_HISTORICO,
            DATA_INIVIGENCIA,
            DATA_MOVIMENTO,
            COD_PRODUTO,
            COD_GRUPO_CAUSA,
            COD_SUBGRUPO_CAUSA,
            NUM_PARTICIPANTE,
            COD_CLIENTE,
            COD_DOCUMENTO,
            COD_FASE,
            COD_EVENTO,
            NUM_CARTA,
            OCORR_HIST_PAI,
            COD_USUARIO,
            TIMESTAMP,
            NOM_SISTEMA_ORIGEM,
            NOM_PROGRAMA,
            STA_INTEGRA_AMSS)
            VALUES
            (:SISINACO-COD-FONTE,
            :SISINACO-NUM-PROTOCOLO-SINI,
            :SISINACO-DAC-PROTOCOLO-SINI,
            :SIPROACO-OCORR-HISTORICO,
            :SICHEPAR-DATA-INIVIGENCIA,
            :SISINACO-DATA-MOVTO-SINIACO,
            :SIMOVSIN-COD-PRODUTO,
            :SINISCAU-COD-GRUPO-CAUSA,
            :SINISCAU-COD-SUBGRUPO-CAUSA,
            3,
            :SIMOVSIN-COD-ESTIPULANTE,
            0,
            2,
            :SISINACO-COD-EVENTO,
            :SISINACO-NUM-CARTA:IND-NUM-CARTA,
            :SIPROACO-OCORR-HISTORICO,
            :SISINACO-COD-USUARIO,
            CURRENT TIMESTAMP,
            'SISWEB' ,
            'PTACOMOS' ,
            'N' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SI_PROTOCOLO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_MOVIMENTO, COD_PRODUTO, COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA, NUM_PARTICIPANTE, COD_CLIENTE, COD_DOCUMENTO, COD_FASE, COD_EVENTO, NUM_CARTA, OCORR_HIST_PAI, COD_USUARIO, TIMESTAMP, NOM_SISTEMA_ORIGEM, NOM_PROGRAMA, STA_INTEGRA_AMSS) VALUES ({FieldThreatment(this.SISINACO_COD_FONTE)}, {FieldThreatment(this.SISINACO_NUM_PROTOCOLO_SINI)}, {FieldThreatment(this.SISINACO_DAC_PROTOCOLO_SINI)}, {FieldThreatment(this.SIPROACO_OCORR_HISTORICO)}, {FieldThreatment(this.SICHEPAR_DATA_INIVIGENCIA)}, {FieldThreatment(this.SISINACO_DATA_MOVTO_SINIACO)}, {FieldThreatment(this.SIMOVSIN_COD_PRODUTO)}, {FieldThreatment(this.SINISCAU_COD_GRUPO_CAUSA)}, {FieldThreatment(this.SINISCAU_COD_SUBGRUPO_CAUSA)}, 3, {FieldThreatment(this.SIMOVSIN_COD_ESTIPULANTE)}, 0, 2, {FieldThreatment(this.SISINACO_COD_EVENTO)},  {FieldThreatment((this.IND_NUM_CARTA?.ToInt() == -1 ? null : this.SISINACO_NUM_CARTA))}, {FieldThreatment(this.SIPROACO_OCORR_HISTORICO)}, {FieldThreatment(this.SISINACO_COD_USUARIO)}, CURRENT TIMESTAMP, 'SISWEB' , 'PTACOMOS' , 'N' )";

            return query;
        }
        public string SISINACO_COD_FONTE { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SIPROACO_OCORR_HISTORICO { get; set; }
        public string SICHEPAR_DATA_INIVIGENCIA { get; set; }
        public string SISINACO_DATA_MOVTO_SINIACO { get; set; }
        public string SIMOVSIN_COD_PRODUTO { get; set; }
        public string SINISCAU_COD_GRUPO_CAUSA { get; set; }
        public string SINISCAU_COD_SUBGRUPO_CAUSA { get; set; }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SISINACO_COD_EVENTO { get; set; }
        public string SISINACO_NUM_CARTA { get; set; }
        public string IND_NUM_CARTA { get; set; }
        public string SISINACO_COD_USUARIO { get; set; }

        public static void Execute(R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 r1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1)
        {
            var ths = r1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}