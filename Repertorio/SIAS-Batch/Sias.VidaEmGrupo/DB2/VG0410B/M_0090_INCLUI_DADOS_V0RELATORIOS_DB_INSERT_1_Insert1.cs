using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0410B
{
    public class M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES (:MOVTO-COD-USUARIO,
            :SISTEMA-DTMOVABE,
            :RELAT-IDSISTEM,
            :RELAT-CODRELAT,
            0,
            0,
            :SISTEMA-DTMOVABE,
            :SISTEMA-DTMOVABE,
            :SISTEMA-DTMOVABE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :MOVTO-NUM-APOLICE,
            0,
            :RELAT-NRPARCEL,
            :MOVTO-NUM-CERTIFIC,
            0,
            :MOVTO-COD-SUBES,
            :RELAT-OPERACAO,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            :RELAT-SITUACAO,
            ' ' ,
            ' ' ,
            NULL,
            NULL,
            NULL,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ({FieldThreatment(this.MOVTO_COD_USUARIO)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.RELAT_IDSISTEM)}, {FieldThreatment(this.RELAT_CODRELAT)}, 0, 0, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.MOVTO_NUM_APOLICE)}, 0, {FieldThreatment(this.RELAT_NRPARCEL)}, {FieldThreatment(this.MOVTO_NUM_CERTIFIC)}, 0, {FieldThreatment(this.MOVTO_COD_SUBES)}, {FieldThreatment(this.RELAT_OPERACAO)}, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , {FieldThreatment(this.RELAT_SITUACAO)}, ' ' , ' ' , NULL, NULL, NULL, CURRENT TIMESTAMP)";

            return query;
        }
        public string MOVTO_COD_USUARIO { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string RELAT_IDSISTEM { get; set; }
        public string RELAT_CODRELAT { get; set; }
        public string MOVTO_NUM_APOLICE { get; set; }
        public string RELAT_NRPARCEL { get; set; }
        public string MOVTO_NUM_CERTIFIC { get; set; }
        public string MOVTO_COD_SUBES { get; set; }
        public string RELAT_OPERACAO { get; set; }
        public string RELAT_SITUACAO { get; set; }

        public static void Execute(M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1 m_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = m_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0090_INCLUI_DADOS_V0RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}