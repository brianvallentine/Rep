using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1 : QueryBasis<R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.V0EMISICOB
            VALUES (:V0ESIC-NRTIT,
            :V0ESIC-CODCDT,
            :V0ESIC-NUMAPOL,
            :V0ESIC-NRENDOS,
            :V0ESIC-NRCERTIF,
            :V0ESIC-FONTE,
            :V0ESIC-NRPROPOS,
            :V0ESIC-NRCARNE,
            :V0ESIC-NRPARCEL,
            :V0ESIC-QTPARCEL,
            :V0ESIC-DTVENCTO,
            :V0ESIC-NRDOCTO,
            :V0ESIC-DTDOCTO,
            :V0ESIC-CORRECAO,
            :V0ESIC-CODUNIMO,
            :V0ESIC-VL-PRM-IX,
            :V0ESIC-VL-PRM-VAR,
            :V0ESIC-RECVENCTO,
            :V0ESIC-IOFINCLUSO,
            :V0ESIC-RECIOF,
            :V0ESIC-CODCLIEN,
            :V0ESIC-OCORR-END,
            :V0ESIC-CODPRODU,
            :V0ESIC-CODPGM,
            :V0ESIC-CODMENS,
            :V0ESIC-SITUACAO,
            CURRENT TIMESTAMP,
            :V0ESIC-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0EMISICOB VALUES ({FieldThreatment(this.V0ESIC_NRTIT)}, {FieldThreatment(this.V0ESIC_CODCDT)}, {FieldThreatment(this.V0ESIC_NUMAPOL)}, {FieldThreatment(this.V0ESIC_NRENDOS)}, {FieldThreatment(this.V0ESIC_NRCERTIF)}, {FieldThreatment(this.V0ESIC_FONTE)}, {FieldThreatment(this.V0ESIC_NRPROPOS)}, {FieldThreatment(this.V0ESIC_NRCARNE)}, {FieldThreatment(this.V0ESIC_NRPARCEL)}, {FieldThreatment(this.V0ESIC_QTPARCEL)}, {FieldThreatment(this.V0ESIC_DTVENCTO)}, {FieldThreatment(this.V0ESIC_NRDOCTO)}, {FieldThreatment(this.V0ESIC_DTDOCTO)}, {FieldThreatment(this.V0ESIC_CORRECAO)}, {FieldThreatment(this.V0ESIC_CODUNIMO)}, {FieldThreatment(this.V0ESIC_VL_PRM_IX)}, {FieldThreatment(this.V0ESIC_VL_PRM_VAR)}, {FieldThreatment(this.V0ESIC_RECVENCTO)}, {FieldThreatment(this.V0ESIC_IOFINCLUSO)}, {FieldThreatment(this.V0ESIC_RECIOF)}, {FieldThreatment(this.V0ESIC_CODCLIEN)}, {FieldThreatment(this.V0ESIC_OCORR_END)}, {FieldThreatment(this.V0ESIC_CODPRODU)}, {FieldThreatment(this.V0ESIC_CODPGM)}, {FieldThreatment(this.V0ESIC_CODMENS)}, {FieldThreatment(this.V0ESIC_SITUACAO)}, CURRENT TIMESTAMP, {FieldThreatment(this.V0ESIC_DTMOVTO)})";

            return query;
        }
        public string V0ESIC_NRTIT { get; set; }
        public string V0ESIC_CODCDT { get; set; }
        public string V0ESIC_NUMAPOL { get; set; }
        public string V0ESIC_NRENDOS { get; set; }
        public string V0ESIC_NRCERTIF { get; set; }
        public string V0ESIC_FONTE { get; set; }
        public string V0ESIC_NRPROPOS { get; set; }
        public string V0ESIC_NRCARNE { get; set; }
        public string V0ESIC_NRPARCEL { get; set; }
        public string V0ESIC_QTPARCEL { get; set; }
        public string V0ESIC_DTVENCTO { get; set; }
        public string V0ESIC_NRDOCTO { get; set; }
        public string V0ESIC_DTDOCTO { get; set; }
        public string V0ESIC_CORRECAO { get; set; }
        public string V0ESIC_CODUNIMO { get; set; }
        public string V0ESIC_VL_PRM_IX { get; set; }
        public string V0ESIC_VL_PRM_VAR { get; set; }
        public string V0ESIC_RECVENCTO { get; set; }
        public string V0ESIC_IOFINCLUSO { get; set; }
        public string V0ESIC_RECIOF { get; set; }
        public string V0ESIC_CODCLIEN { get; set; }
        public string V0ESIC_OCORR_END { get; set; }
        public string V0ESIC_CODPRODU { get; set; }
        public string V0ESIC_CODPGM { get; set; }
        public string V0ESIC_CODMENS { get; set; }
        public string V0ESIC_SITUACAO { get; set; }
        public string V0ESIC_DTMOVTO { get; set; }

        public static void Execute(R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1 r3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1)
        {
            var ths = r3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_00_INSERT_V0EMISICOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}