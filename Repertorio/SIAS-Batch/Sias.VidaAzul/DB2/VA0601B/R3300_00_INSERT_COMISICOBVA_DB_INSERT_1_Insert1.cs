using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1 : QueryBasis<R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.COMISS_ADIAN_SICOB
            VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF,
            :WHOST-FONTE,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR ,
            :DCLRCAPS.RCAPS-VAL-RCAP,
            :DCLCOMISS-ADIAN-SICOB.VAL-ADIANTAMENTO,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :DCLCOMISS-ADIAN-SICOB.SIT-REGISTRO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN ,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            CURRENT TIMESTAMP,
            :DCLCOMISS-ADIAN-SICOB.SIT-FENAE,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO,
            :DCLCOMISS-ADIAN-SICOB.VAL-COMISSAO-VEN,
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE,
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO,
            :DCLCOMISS-ADIAN-SICOB.ORDEM-PAGAMENTO,
            :DCLCOMISS-ADIAN-SICOB.NUM-ENDOSSO,
            :DCLCOMISS-ADIAN-SICOB.NUM-MATR-GERENTE,
            :DCLCOMISS-ADIAN-SICOB.COD-AGEN-GERENTE,
            :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-GERENTE,
            :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-GERENTE,
            :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-GERENTE,
            :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-GERENTE,
            :DCLCOMISS-ADIAN-SICOB.NUM-MATR-SUN,
            :DCLCOMISS-ADIAN-SICOB.COD-AGEN-SUN,
            :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-SUN,
            :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-SUN,
            :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-SUN,
            :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-SUN)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.COMISS_ADIAN_SICOB VALUES ({FieldThreatment(this.PROPOFID_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.WHOST_FONTE)}, {FieldThreatment(this.PROPOFID_AGECOBR)} , {FieldThreatment(this.RCAPS_VAL_RCAP)}, {FieldThreatment(this.VAL_ADIANTAMENTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SIT_REGISTRO)}, {FieldThreatment(this.PROPOFID_AGECTAVEN)} , {FieldThreatment(this.PROPOFID_OPRCTAVEN)} , {FieldThreatment(this.PROPOFID_NUMCTAVEN)} , {FieldThreatment(this.PROPOFID_DIGCTAVEN)} , {FieldThreatment(this.PROPOFID_NRMATRVEN)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, CURRENT TIMESTAMP, {FieldThreatment(this.SIT_FENAE)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.VAL_COMISSAO_VEN)}, {FieldThreatment(this.PROPSSVD_NUM_APOLICE)}, {FieldThreatment(this.PROPSSVD_COD_SUBGRUPO)}, {FieldThreatment(this.ORDEM_PAGAMENTO)}, {FieldThreatment(this.NUM_ENDOSSO)}, {FieldThreatment(this.NUM_MATR_GERENTE)}, {FieldThreatment(this.COD_AGEN_GERENTE)}, {FieldThreatment(this.OPE_CONTA_GERENTE)}, {FieldThreatment(this.NUM_CONTA_GERENTE)}, {FieldThreatment(this.DIG_CONTA_GERENTE)}, {FieldThreatment(this.VAL_COMIS_GERENTE)}, {FieldThreatment(this.NUM_MATR_SUN)}, {FieldThreatment(this.COD_AGEN_SUN)}, {FieldThreatment(this.OPE_CONTA_SUN)}, {FieldThreatment(this.NUM_CONTA_SUN)}, {FieldThreatment(this.DIG_CONTA_SUN)}, {FieldThreatment(this.VAL_COMIS_SUN)})";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string WHOST_FONTE { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string VAL_ADIANTAMENTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string SIT_FENAE { get; set; }
        public string VAL_COMISSAO_VEN { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string ORDEM_PAGAMENTO { get; set; }
        public string NUM_ENDOSSO { get; set; }
        public string NUM_MATR_GERENTE { get; set; }
        public string COD_AGEN_GERENTE { get; set; }
        public string OPE_CONTA_GERENTE { get; set; }
        public string NUM_CONTA_GERENTE { get; set; }
        public string DIG_CONTA_GERENTE { get; set; }
        public string VAL_COMIS_GERENTE { get; set; }
        public string NUM_MATR_SUN { get; set; }
        public string COD_AGEN_SUN { get; set; }
        public string OPE_CONTA_SUN { get; set; }
        public string NUM_CONTA_SUN { get; set; }
        public string DIG_CONTA_SUN { get; set; }
        public string VAL_COMIS_SUN { get; set; }

        public static void Execute(R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1 r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1)
        {
            var ths = r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}